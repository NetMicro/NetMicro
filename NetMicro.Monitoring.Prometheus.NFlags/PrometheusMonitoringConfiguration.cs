using NFlags.Commands;

namespace NetMicro.Monitoring.Prometheus.NFlags
{
    public class PrometheusMonitoringConfiguration : IPrometheusMonitoringConfiguration
    {
        private readonly CommandArgs _commandArgs;

        public PrometheusMonitoringConfiguration(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public bool Enabled => _commandArgs.GetFlag(PrometheusFlags.Enabled);
        public string Path => _commandArgs.GetOption<string>(PrometheusOptions.Path);
    }
}