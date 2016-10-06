using Autofac;
using CarLookUp.Services.Services;
using CarLookUp.Services.Services.Interfaces;

namespace CarLookUp.Services.Ioc
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Data.Ioc.IocModule());
            builder.RegisterType<CarServices>().As<ICarServices>();
            builder.RegisterType<BodyTypeServices>().As<IBodyTypeServices>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<LoginService>().As<ILoginService>();
        }
    }
}
