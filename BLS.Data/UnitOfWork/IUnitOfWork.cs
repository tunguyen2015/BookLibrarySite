using BLS.Data.Repository;
using System;
using System.Threading.Tasks;
using BLS.Core;

namespace BLS.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<T> Repository<T>() where T : BaseEntity;
        void Save();
    }
}
