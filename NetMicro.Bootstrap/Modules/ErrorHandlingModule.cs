using Autofac;
using NetMicro.ErrorHandling;
using NetMicro.Routing.Modules;

namespace NetMicro.Bootstrap.Modules
{
    public class ErrorHandlingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Bootstrap.ErrorHandlingModule>()
                .As<IModule>()
                .SingleInstance();
            builder
                .RegisterType<ExceptionStatusCodeMapper>()
                .SingleInstance();
        }
    }
}