using Amendment.Server.Model.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amendment.Server.Repository.Infrastructure
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, ITableBase
    {
        // Marks an entity as new
        Task AddAsync(T entity);
        // Marks an entity as modified
        Task UpdateAsync(T entity);
        // Marks an entity to be removed
        Task DeleteAsync(T entity);
        Task DeleteAsync(params Expression<Func<T, bool>>[] where);
    }

    public abstract class BaseRepository<T> : BaseReadOnlyRepository<T>, IRepository<T> where T : class, ITableBase
    {
        private readonly IDbFactory _dbFactory;

        protected BaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public virtual async Task AddAsync(T entity)
        {
            var context = _dbFactory.Init();
            var dbSet = context.Set<T>();
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var context = _dbFactory.Init();
            var dbSet = context.Set<T>();
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        protected virtual async Task UpdateAsync(T entity, params string[] properties)
        {
            var context = _dbFactory.Init();
            context.Entry(entity).State = EntityState.Detached;
            foreach (var property in properties)
            {
                context.Entry(entity).Property(property).IsModified = true;
            }
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var context = _dbFactory.Init();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(params Expression<Func<T, bool>>[] where)
        {
            var context = _dbFactory.Init();
            var dbSet = context.Set<T>();
            IEnumerable<T> objects = dbSet.WhereMany(where).AsEnumerable();
            foreach (T obj in objects)
                context.Remove(obj);
            await context.SaveChangesAsync();
        }
    }
}
