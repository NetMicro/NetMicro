using Autofac;

namespace NetMicro.Binding.Controllers.Autofac
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(Controller<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(BoundRequestController<,>))
                .InstancePerDependency();
        }
    }
}