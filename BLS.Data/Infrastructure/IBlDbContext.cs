using System.Data.Entity;
using System.Threading.Tasks;
using BLS.Core;

namespace BLS.Data.Infrastructure
{
    public interface IBlDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity<int>;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
