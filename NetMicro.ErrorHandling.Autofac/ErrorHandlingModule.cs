using Autofac;
using NetMicro.Routing.Modules;

namespace NetMicro.ErrorHandling.Autofac
{
    public class ErrorHandlingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ErrorHandling.ErrorHandlingModule>()
                .As<IModule>()
                .SingleInstance();

            builder
                .RegisterType<ExceptionStatusCodeMapper>()
                .SingleInstance();
        }
    }
}