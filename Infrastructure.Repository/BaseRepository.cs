using Domain.Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
        public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
        {
            private readonly SqlContext _context;

            public BaseRepository(SqlContext Context)
            {
                _context = Context;
            }

            public virtual TEntity Add(TEntity obj)
            {
                try
                {
                    var addedEntity = _context.Set<TEntity>().Add(obj);
                    _context.SaveChanges();
                    return addedEntity.Entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public virtual TEntity GetById(int id)
            {
                return _context.Set<TEntity>().Find(id);
            }

            public virtual IEnumerable<TEntity> GetAll()
            {
                return _context.Set<TEntity>().ToList();
            }

        public virtual TEntity Update(TEntity obj)
        {
            try
            {
                var entityId = _context.Entry(obj).Property("Id").CurrentValue;
                var entity = _context.Set<TEntity>().Find(entityId);

                if (entity != null)
                {
                    _context.Entry(entity).CurrentValues.SetValues(obj);
                    _context.SaveChanges();
                    return entity; 
                }
                else
                {
                    throw new InvalidDataException("Entity not found.");
                }
            }
            catch (Exception ex)
            {
                // Adiciona contexto ao relançar a exceção
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        public virtual void Remove(TEntity obj)
            {
                try
                {
                    _context.Set<TEntity>().Remove(obj);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            public virtual void Dispose()
            {
                _context.Dispose();
            }


        }
    }

