using System;

namespace NetMicro.Consul
{
    public interface IConsulConfiguration
    {
        bool Enabled { get; }
        Uri ConsulAddress { get; }
        Uri ServiceUri { get; }
        string ServiceId { get; }
        string ServiceName { get; }
        string[] Tags { get; }
    }
}