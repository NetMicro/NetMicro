using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace NetMicro.Monitoring.Prometheus
{
    public static class ApplicationBuilderExtension
    {
        public static void EnablePrometheusMonitoring(this IApplicationBuilder app,
            IPrometheusMonitoringConfiguration prometheusMonitoringConfiguration)
        {
            if (!prometheusMonitoringConfiguration.Enabled)
                return;

            app.UseMetricServer(prometheusMonitoringConfiguration.Path);
        }
    }
}