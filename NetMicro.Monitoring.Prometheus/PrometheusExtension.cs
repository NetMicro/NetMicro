using Microsoft.AspNetCore.Builder;

namespace NetMicro.Monitoring.Prometheus
{
    public class PrometheusExtension : IExtension
    {
        private readonly IApplicationBuilder _applicationBuilder;
        private readonly IPrometheusMonitoringConfiguration _prometheusMonitoringConfiguration;

        public PrometheusExtension(IApplicationBuilder applicationBuilder,
            IPrometheusMonitoringConfiguration prometheusMonitoringConfiguration)
        {
            _prometheusMonitoringConfiguration = prometheusMonitoringConfiguration;
            _applicationBuilder = applicationBuilder;
        }

        public void Extend()
        {
            _applicationBuilder.EnablePrometheusMonitoring(_prometheusMonitoringConfiguration);
        }
    }
}