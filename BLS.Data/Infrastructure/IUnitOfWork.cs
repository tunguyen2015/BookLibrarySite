using System;
using BLS.Core;
using BLS.Data.Repository;

namespace BLS.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<T> Repository<T>() where T : BaseEntity<int>;
        void Save();
    }
}
