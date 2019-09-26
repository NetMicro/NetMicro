using Autofac;

namespace NetMicro.Queues.Simple.Autofac
{
    public class SimpleQueuesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof (Channel<>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(Consumer<>)).As(typeof(IConsumer<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Producer<>)).As(typeof(IProducer<>)).InstancePerDependency();
        }
    }
}