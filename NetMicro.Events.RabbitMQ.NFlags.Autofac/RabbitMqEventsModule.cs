using Autofac;

namespace NetMicro.Events.RabbitMQ.NFlags.Autofac
{
    public class RabbitMqEventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EventReceiver<>)).As(typeof(IEventReceiver<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(EventEmitter<>)).As(typeof(IEventEmitter<>)).InstancePerDependency();
        }
    }
}