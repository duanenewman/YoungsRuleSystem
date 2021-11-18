using Amendment.Server.Model.Infrastructure;
using Amendment.Server.Repository.Infrastructure;

namespace Amendment.Server.Services.Infrastructure
{
    public sealed class GenericDataService<T> : BaseDataService<T> where T : class, ITableBase
    {
        public GenericDataService(IRepository<T> repository) : base(repository)
        {
        }
    }
}
