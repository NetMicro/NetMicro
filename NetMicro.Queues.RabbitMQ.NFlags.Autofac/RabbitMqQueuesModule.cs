using Autofac;
using RabbitMQ.Client;

namespace NetMicro.Queues.RabbitMQ.NFlags.Autofac
{
    public class RabbitMqQueuesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Consumer<>)).As(typeof(IConsumer<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Producer<>)).As(typeof(IProducer<>)).InstancePerDependency();
        }
    }
}