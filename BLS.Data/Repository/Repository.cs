using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLS.Core;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace BLS.Data.Repository
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly BlDbContext _context;
        private IDbSet<T> _entities;
        private string _errorMessage = string.Empty;

        public Repository(BlDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                Entities.Add(entity);
                await _context.SaveChangesAsync();
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

        public async Task<T> Edit(T entity, int key)
        {
            if (entity == null)
            {
                return null;
            }

            var existingObject = await _context.Set<T>().FindAsync(key);

            if (existingObject != null)
            {
                _context.Entry(existingObject).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existingObject;
        }

        public async Task<int> Delete(T entity)
        {
            Entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> Table => Entities;

        private IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
