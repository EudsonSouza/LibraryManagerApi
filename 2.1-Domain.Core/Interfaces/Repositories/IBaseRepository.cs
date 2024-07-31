using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
