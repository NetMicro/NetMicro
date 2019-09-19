using Autofac;

namespace NetMicro.Controllers.Autofac
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(Controller<>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(RequestControllerExecutor<>))
                .As(typeof(IRequestControllerExecutor<>))
                .InstancePerDependency();
        }
    }
}