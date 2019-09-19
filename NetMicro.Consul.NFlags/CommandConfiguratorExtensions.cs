using NFlags.Commands;

namespace NetMicro.Consul.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string ConsulGroup = "Consul";

        public static CommandConfigurator RegisterConsulServiceDiscovery(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(ConsulFlags.Enabled)
                    .Description("True, if service should be registered in Consul service discovery")
                    .ConfigPath("Consul:Enabled")
                    .EnvironmentVariable("CONSUL_ENABLED")
                    .DefaultValue(false)
                    .Group(ConsulGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(ConsulOptions.ConsulAddress)
                    .Description("Address of consul cluster")
                    .ConfigPath("Consul:Address")
                    .EnvironmentVariable("CONSUL_ADDRESS")
                    .Group(ConsulGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(ConsulOptions.ServiceId)
                    .Description("Service id for Consul service discovery")
                    .ConfigPath("Consul:Service:Id")
                    .EnvironmentVariable("CONSUL_SERVICE_ID")
                    .Group(ConsulGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(ConsulOptions.ServiceName)
                    .Description("Service name for Consul service discovery")
                    .ConfigPath("Consul:Service:Name")
                    .EnvironmentVariable("CONSUL_SERVICE_NAME")
                    .Group(ConsulGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(ConsulOptions.ServiceUri)
                    .Description("Service Uri for Consul service discovery")
                    .ConfigPath("Consul:Service:Uri")
                    .EnvironmentVariable("CONSUL_SERVICE_URI")
                    .Group(ConsulGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(ConsulOptions.ServiceTags)
                    .Description("Service Tags for Consul service discovery (separated by comma)")
                    .ConfigPath("Consul:Service:Tags")
                    .EnvironmentVariable("CONSUL_SERVICE_TAGS")
                    .Group(ConsulGroup)
                );
        }
    }
}