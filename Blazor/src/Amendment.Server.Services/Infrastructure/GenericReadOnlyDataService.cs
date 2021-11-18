using Amendment.Server.Model.Infrastructure;
using Amendment.Server.Repository.Infrastructure;

namespace Amendment.Server.Services.Infrastructure
{
    public sealed class GenericReadOnlyDataService<T> : BaseReadOnlyDataService<T> where T : class, IReadOnlyTable
    {
        public GenericReadOnlyDataService(IReadOnlyRepository<T> repository) : base(repository)
        {
        }
    }
}
