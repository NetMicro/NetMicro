using Autofac;

namespace NetMicro.Workers.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseWorkers(this ContainerBuilder builder)
        {
            builder.RegisterModule<WorkersExtensionModule>();
        }
    }
}