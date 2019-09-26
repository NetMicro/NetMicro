using Autofac;

namespace NetMicro.Events.Simple.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseSimpleEvents(this ContainerBuilder builder)
        {
            builder.RegisterModule<SimpleEventsModule>();
        }
    }
}