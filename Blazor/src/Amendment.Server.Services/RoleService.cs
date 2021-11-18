using Amendment.Server.Model.DataModel;
using Amendment.Server.Repository.Infrastructure;
using Amendment.Server.Services.Infrastructure;
using System.Threading.Tasks;

namespace Amendment.Server.Services
{
    public interface IRoleService : IReadOnlyDataService<Role>
    {
        Task<Role> GetByNameAsync(string roleName);
    }

    public class RoleService : BaseReadOnlyDataService<Role>, IRoleService
    {
        private readonly IReadOnlyRepository<Role> _repository;

        public RoleService(IReadOnlyRepository<Role> repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<Role> GetByNameAsync(string roleName)
        {
            return _repository.GetAsync(r => r.Name == roleName);
        }
    }
}
