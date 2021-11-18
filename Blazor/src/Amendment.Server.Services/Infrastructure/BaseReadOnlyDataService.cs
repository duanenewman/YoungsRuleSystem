using Amendment.Server.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amendment.Server.Repository.Infrastructure;
using System.Linq;

namespace Amendment.Server.Services.Infrastructure
{
    public interface IReadOnlyDataService<T> where T : IReadOnlyTable
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
    }

    public abstract class BaseReadOnlyDataService<T> : IReadOnlyDataService<T> where T : class, IReadOnlyTable
    {
        private readonly IReadOnlyRepository<T> _repository;

        protected BaseReadOnlyDataService(IReadOnlyRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public virtual Task<T> GetAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
