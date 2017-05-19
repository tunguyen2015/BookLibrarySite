using System.Data.Entity;
using System.Threading.Tasks;
using BLS.Core;

namespace BLS.Data.Infrastructure
{
    internal interface IDbAsyncSet<T> : IDbSet<T> where T : BaseEntity<int>
    {
        Task<T> FindAsync(params object[] keyValues);
    }
}
