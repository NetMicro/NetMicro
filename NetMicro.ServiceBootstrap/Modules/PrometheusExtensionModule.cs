using Autofac;
using NetMicro.Monitoring.Prometheus;
using NetMicro.Monitoring.Prometheus.NFlags;
using NetMicro.Routing.Modules;
using NetMicro.ServiceBootstrap.Extensions;

namespace NetMicro.ServiceBootstrap.Modules
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