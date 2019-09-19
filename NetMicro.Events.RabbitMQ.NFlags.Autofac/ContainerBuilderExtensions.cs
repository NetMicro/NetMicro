using Autofac;

namespace NetMicro.Events.RabbitMQ.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseRabbitMqEvents(this ContainerBuilder builder)
        {
            builder.RegisterModule<RabbitMqEventsModule>();
        }
    }
}