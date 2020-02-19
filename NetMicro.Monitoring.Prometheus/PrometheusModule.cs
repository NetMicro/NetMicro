using NetMicro.Routing;
using NetMicro.Routing.Modules;

namespace NetMicro.Monitoring.Prometheus
{
    public class PrometheusModule : IModule
    {
        private readonly IPrometheusMonitoringConfiguration _prometheusMonitoringConfiguration;

        public PrometheusModule(IPrometheusMonitoringConfiguration prometheusMonitoringConfiguration)
        {
            _prometheusMonitoringConfiguration = prometheusMonitoringConfiguration;
        }

        public void Configure(IRouter router)
        {
            router.EnablePrometheusMonitoring(_prometheusMonitoringConfiguration);
        }
    }
}