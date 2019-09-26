using Autofac;

namespace NetMicro.Queues.Simple.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseSimpleQueues(this ContainerBuilder builder)
        {
            builder.RegisterModule<SimpleQueuesModule>();
        }
    }
}