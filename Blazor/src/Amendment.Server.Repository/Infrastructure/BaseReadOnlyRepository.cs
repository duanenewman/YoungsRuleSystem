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
    public interface IReadOnlyRepository<T> where T : class, IReadOnlyTable
    {
        // Get an entity by int id
        Task<T> GetByIdAsync(int id);
        // Get an entity using delegate
        Task<T> GetAsync(params Expression<Func<T, bool>>[] where);
        // Gets all entities of type T
        Task<IEnumerable<T>> GetAllAsync();
        // Gets entities using delegate
        Task<ListResults<T>> GetManyAsync(string orderBy = "", int pageNumber = 1, int pageSize = int.MaxValue, params Expression<Func<T, bool>>[] @where);
        Task<int> CountAsync(params Expression<Func<T, bool>>[] where);
        Task<int> CountAsync();
    }

    public abstract class BaseReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class, IReadOnlyTable
    {
        protected readonly IDbFactory _dbFactory;

        protected virtual DbSet<T> ActivateContext() => _dbFactory.Init().Set<T>();

        protected BaseReadOnlyRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public virtual async Task<int> CountAsync(params Expression<Func<T, bool>>[] where)
        {
            return await ActivateContext().WhereMany(where).CountAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await ActivateContext().CountAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await ActivateContext().ToListAsync();
        }

        public virtual Task<T> GetAsync(params Expression<Func<T, bool>>[] where)
        {
            return GetAsync(ActivateContext(), where);
        }

        protected virtual async Task<T> GetAsync(IQueryable<T> query, params Expression<Func<T, bool>>[] where)
        {
            var result = await query.WhereMany(where).FirstOrDefaultAsync<T>();
            if (result == null)
                return null;
            return ChildRecordSelector(result);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var results = await ActivateContext().SingleOrDefaultAsync(e => e.Id == id);
            if (results == null)
                return null;

            return ChildRecordSelector(results);
        }

        public virtual Task<ListResults<T>> GetManyAsync(string orderBy = "", int pageNumber = 1, int pageSize = int.MaxValue, params Expression<Func<T, bool>>[] where)
        {
            return GetManWithIncludeAsync(ActivateContext(), orderBy, pageNumber, pageSize, @where);
        }

        private async Task<ListResults<T>> GetManWithIncludeAsync(IQueryable<T> query, string orderBy = "", int pageNumber = 1, int pageSize = int.MaxValue, params Expression<Func<T, bool>>[] @where)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var output = new ListResults<T>
            {
                TotalCount = await CountAsync()
            };

            if (where != null)
                query = query.WhereMany(where);

            output.FilteredCount = await CountAsync(query);

            if (!string.IsNullOrEmpty(orderBy))
                query = query.OrderByJsonApi(orderBy);

            if (pageNumber < 1)
                pageNumber = 1;

            output.PageNumber = pageNumber;
            pageNumber = pageNumber - 1;

            query = query.Skip(pageNumber * pageSize);
            query = query.Take(pageSize);

            output.Results = await query.ToListAsync();

            if (output.FilteredCount == 0)
                return output;

            output.Results = output.Results.Select(ChildRecordSelector).ToList();

            return output;
        }

        private async Task<int> CountAsync(IQueryable<T> query)
        {
            return await query.CountAsync();
        }

        protected virtual T ChildRecordSelector(T s)
        {
            return s;
        }
    }
}
