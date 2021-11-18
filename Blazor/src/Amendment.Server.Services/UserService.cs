using Amendment.Server.Model.DataModel;
using Amendment.Server.Repository.Infrastructure;
using Amendment.Server.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amendment.Server.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetAsync(string userName);
        Task<User> GetForToastAsync(int userId);
    }

    public class UserService : BaseDataService<User>, IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<User> GetAsync(string userName)
        {
            return _repository.GetAsync(u => String.Equals(u.Username, userName, StringComparison.CurrentCultureIgnoreCase));
        }

        public override async Task<IOperationResult> CreateAsync(User item, int userId)
        {
            var dupeCount = await _repository.CountAsync(u => u.Username == item.Username);
            if (dupeCount > 0)
                return new OperationResult(OperationType.Create, false, $"A user is already present with the username '{item.Username}'");
            return await base.CreateAsync(item, userId);
        }

        public override async Task<IOperationResult> UpdateAsync(User item, int userId)
        {
            var dupeCount = await _repository.CountAsync(u => u.Username == item.Username && u.Id != item.Id);
            if (dupeCount > 0)
                return new OperationResult(OperationType.Update, false, $"A user is already present with the username '{item.Username}'");
            return await base.UpdateAsync(item, userId);
        }

        public async Task<User> GetForToastAsync(int userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                return null;

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username
            };
        }
    }
}
