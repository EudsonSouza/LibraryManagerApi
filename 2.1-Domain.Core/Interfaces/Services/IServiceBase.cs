using System;
using System.Collections.Generic;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
