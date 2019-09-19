using Autofac;

namespace NetMicro.Queues.RabbitMQ.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseRabbitMqQueues(this ContainerBuilder builder)
        {
            builder.RegisterModule<RabbitMqQueuesModule>();
        }
    }
}