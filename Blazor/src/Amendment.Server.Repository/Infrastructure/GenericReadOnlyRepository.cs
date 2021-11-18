using Amendment.Server.Model.Infrastructure;

namespace Amendment.Server.Repository.Infrastructure
{
    public sealed class GenericReadOnlyRepository<T> : BaseReadOnlyRepository<T> where T : class, IReadOnlyTable
    {
        public GenericReadOnlyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
