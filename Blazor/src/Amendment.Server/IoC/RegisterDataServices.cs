using Amendment.Server.Repository.Infrastructure;
using Amendment.Server.Services;
using Amendment.Server.Services.Infrastructure;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using System.Reflection;

namespace Amendment.Server.IoC
{
    public class RegisterDataServices : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericReadOnlyRepository<>)).As(typeof(IReadOnlyRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericDataService<>)).As(typeof(IDataService<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericReadOnlyDataService<>)).As(typeof(IReadOnlyDataService<>)).InstancePerLifetimeScope();

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GenericRepository<>).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository"))//.Except<InMemoryShapeRepository>().Except<CartoShapeRepository>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            // Services
            builder.RegisterAssemblyTypes(typeof(UserService).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
