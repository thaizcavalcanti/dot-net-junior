using Model.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Infraestrutura.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbContext.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task SaveChanges()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
