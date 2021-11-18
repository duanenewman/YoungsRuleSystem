using Amendment.Server.Model.Infrastructure;
using Amendment.Server.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amendment.Server.Services.Infrastructure
{
    public interface IDataService<T> : IReadOnlyDataService<T> where T : ITableBase
    {
        Task<IOperationResult> CreateAsync(T item, int userId);
        Task<IOperationResult> UpdateAsync(T item, int userId);
        Task<IOperationResult> DeleteAsync(T item, int userId);
    }

    public abstract class BaseDataService<T> : BaseReadOnlyDataService<T>, IDataService<T> where T : class, ITableBase
    {
        private readonly IRepository<T> _repository;

        protected BaseDataService(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task<IOperationResult> CreateAsync(T item, int userId)
        {
            await _repository.AddAsync(item);
            return new OperationResult(OperationType.Create);
        }

        public virtual async Task<IOperationResult> UpdateAsync(T item, int userId)
        {
            await _repository.UpdateAsync(item);
            return new OperationResult(OperationType.Update);
        }

        public virtual async Task<IOperationResult> DeleteAsync(T item, int userId)
        {
            await _repository.DeleteAsync(item);
            return new OperationResult(OperationType.Delete);
        }
    }
}
