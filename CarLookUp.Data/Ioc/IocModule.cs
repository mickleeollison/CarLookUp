using Autofac;
using CarLookUp.Data.DAL;
using CarLookUp.Data.DAL.interfaces;
using CarLookUp.Data.Repositories;
using CarLookUp.Data.Repositories.Interfaces;

namespace CarLookUp.Data.Ioc
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Core.Ioc.IocModule());

            builder.RegisterType<CarContext>().As<ICarContext>().InstancePerRequest();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<BodyTypeRepository>().As<IBodyTypeRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
        }
    }
}
