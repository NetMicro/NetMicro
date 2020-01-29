using Autofac;
using NetMicro.ServiceBootstrap.Modules;

namespace NetMicro.ServiceBootstrap
{
    public static class ContainerBuilderExtensions
    {
        public static void UseConsul(this ContainerBuilder builder)
        {
            builder.RegisterModule<ConsulExtensionModule>();
        }

        public static void UsePrometheus(this ContainerBuilder builder)
        {
            builder.RegisterModule<PrometheusExtensionModule>();
        }
    }
}