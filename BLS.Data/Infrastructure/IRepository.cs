using System.Collections.Generic;
using System.Linq;
using BLS.Core;

namespace BLS.Data.Infrastructure
{
    public interface IRepository<T> where T: BaseEntity<int>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Add(T entity);
        T Edit(T entity, int key);
        void Delete(object id);
        IQueryable<T> Table { get; }
    }
}
