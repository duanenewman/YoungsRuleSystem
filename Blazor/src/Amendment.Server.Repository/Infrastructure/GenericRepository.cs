using Amendment.Server.Model.Infrastructure;

namespace Amendment.Server.Repository.Infrastructure
{
    public sealed class GenericRepository<T> : BaseRepository<T> where T : class, ITableBase
    {
        public GenericRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
