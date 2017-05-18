using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLS.Core;

namespace BLS.Data.Repository
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Add(T entity);
        Task<T> Edit(T entity, int key);
        Task<int> Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
