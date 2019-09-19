using System;
using System.Linq;
using NFlags.Commands;

namespace NetMicro.Consul.NFlags
{
    public class ConsulConfiguration : IConsulConfiguration
    {
        private readonly CommandArgs _commandArgs;

        public ConsulConfiguration(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public bool Enabled => _commandArgs.GetFlag(ConsulFlags.Enabled);
        public Uri ConsulAddress => new Uri(_commandArgs.GetOption<string>(ConsulOptions.ConsulAddress));
        public Uri ServiceUri => new Uri(_commandArgs.GetOption<string>(ConsulOptions.ServiceUri));
        public string ServiceId => _commandArgs.GetOption<string>(ConsulOptions.ServiceId);
        public string ServiceName => _commandArgs.GetOption<string>(ConsulOptions.ServiceName);

        public string[] Tags => _commandArgs
            .GetOption<string>(ConsulOptions.ServiceTags)
            .Split(",")
            .Select(s => s.Trim()).ToArray();
    }
}