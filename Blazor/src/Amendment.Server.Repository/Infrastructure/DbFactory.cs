using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amendment.Server.Repository.Infrastructure
{
    public interface IDbFactory<T> where T : DbContext
    {
        T Init();
    }

    public class DbFactory<T> : IDbFactory<T> where T : DbContext
    {
        private readonly DbContextOptions<T> _options;

        public DbFactory(DbContextOptions<T> options)
        {
            _options = options;
        }

        public T Init()
        {
            return (T)Activator.CreateInstance(typeof(T), _options);
        }
    }

    public interface IDbFactory
    {
        AmendmentContext Init();
    }

    public class DbFactory : IDbFactory
    {
        private readonly DbContextOptions<AmendmentContext> _options;

        public DbFactory(DbContextOptions<AmendmentContext> options)
        {
            _options = options;
        }

        public AmendmentContext Init()
        {
            return new AmendmentContext(_options);
        }
    }
}
