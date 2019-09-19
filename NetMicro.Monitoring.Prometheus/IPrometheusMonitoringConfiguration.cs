namespace NetMicro.Monitoring.Prometheus
{
    public interface IPrometheusMonitoringConfiguration
    {
        bool Enabled { get; }
        string Path { get; }
    }
}