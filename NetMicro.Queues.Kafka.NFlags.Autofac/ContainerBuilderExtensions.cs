using Autofac;

namespace NetMicro.Queues.Kafka.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseKafka(this ContainerBuilder builder)
        {
            builder.RegisterModule<KafkaQueuesModule>();
        }
    }
}