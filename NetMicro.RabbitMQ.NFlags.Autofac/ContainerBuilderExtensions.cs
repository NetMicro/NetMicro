using Autofac;

namespace NetMicro.RabbitMQ.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseRabbitMq(this ContainerBuilder builder)
        {
            builder.RegisterModule<RabbitMqModule>();
        }
    }
}