using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BH.DTOL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }

        void Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task SaveAsync();

        void Save();
    }
}
