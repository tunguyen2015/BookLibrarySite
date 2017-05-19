using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLS.Core.Infrastructure
{
    public interface IRepository<T> where T: BaseEntity<int>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Edit(T entity, int key);
        Task<int> Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
