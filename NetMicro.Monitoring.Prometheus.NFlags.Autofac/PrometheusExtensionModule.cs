using Autofac;
using NetMicro.Routing.Modules;

namespace NetMicro.Monitoring.Prometheus.NFlags.Autofac
{
    public class PrometheusExtensionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PrometheusMonitoringConfiguration>()
                .As<IPrometheusMonitoringConfiguration>()
                .SingleInstance();
            builder
                .RegisterType<PrometheusExtension>()
                .As<IExtension>()
                .SingleInstance();
            builder
                .RegisterType<PrometheusModule>()
                .As<IModule>()
                .SingleInstance();
        }
    }
}