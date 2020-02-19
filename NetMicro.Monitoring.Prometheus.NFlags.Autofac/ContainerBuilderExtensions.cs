using Autofac;

namespace NetMicro.Monitoring.Prometheus.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UsePrometheus(this ContainerBuilder builder)
        {
            builder.RegisterModule<PrometheusExtensionModule>();
        }
    }
}