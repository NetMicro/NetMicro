using Autofac;

namespace NetMicro.Presenters.Autofac
{
    public class PresentersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PresenterResolver>()
                .InstancePerLifetimeScope();

            builder
                .Register(componentContext => componentContext.Resolve<PresenterResolver>().Create())
                .InstancePerLifetimeScope();
        }
    }
}