using NFlags.Commands;

namespace NetMicro.Monitoring.Prometheus.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string PrometheusGroup = "Prometheus";

        public static CommandConfigurator RegisterPrometheusMetrics(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(PrometheusFlags.Enabled)
                    .Description("True, if service should provide metrics for Prometheus")
                    .ConfigPath("Prometheus:Enabled")
                    .EnvironmentVariable("CONSUL_ENABLED")
                    .DefaultValue(false)
                    .Group(PrometheusGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(PrometheusOptions.Path)
                    .Description("Path of metrics endpoint")
                    .ConfigPath("Prometheus:Uri")
                    .EnvironmentVariable("PROMETHEUS_PATH")
                    .DefaultValue("/metrics")
                    .Group(PrometheusGroup)
                );
        }
    }
}