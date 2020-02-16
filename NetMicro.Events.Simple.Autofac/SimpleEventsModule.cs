using Autofac;

namespace NetMicro.Events.Simple.Autofac
{
    public class SimpleEventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof (Channel)).SingleInstance();

            builder.RegisterGeneric(typeof (EventReceiver<>)).As(typeof (IEventReceiver<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof (EventEmitter<>)).As(typeof (IEventEmitter<>)).InstancePerDependency();
        }
    }
}