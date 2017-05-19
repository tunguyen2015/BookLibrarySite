using System;
using System.Collections.Generic;
using System.Linq;
using BLS.Core;
using System.Data.Entity;
using System.Data.Entity.Validation;
using BLS.Data.BLDbContext;
using BLS.Data.Infrastructure;

namespace BLS.Data.Repository
{
    public class Repository<T> : IRepository<T> where T: BaseEntity<int>
    {
        private readonly BlDbContext _context;
        private IDbSet<T> _entities;
        private string _errorMessage = string.Empty;

        public Repository(BlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public T Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += $"Error {validationError.ErrorMessage} in Property {validationError.PropertyName}" + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
            return entity;
        }

        public T Edit(T entity, int key)
        {
            if (entity == null)
            {
                return null;
            }

            var existingObject = _context.Set<T>().Find(key);

            if (existingObject != null)
            {
                _context.Entry(existingObject).CurrentValues.SetValues(entity);
                _context.SaveChangesAsync();
            }
            return existingObject;
        }

        public void Delete(object id)
        {
            var entities = Entities.Find(id);
            Entities.Remove(entities);
            _context.SaveChanges();
        }

        public virtual IQueryable<T> Table => Entities;

        private IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
