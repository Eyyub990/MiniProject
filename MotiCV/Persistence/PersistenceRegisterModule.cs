using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PersistenceRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DbContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
