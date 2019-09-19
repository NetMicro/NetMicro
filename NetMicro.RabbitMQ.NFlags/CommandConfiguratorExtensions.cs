using NFlags.Commands;

namespace NetMicro.Queues.RabbitMQ.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string RabbitMqGroup = "RabbitMQ";

        public static CommandConfigurator RegisterRabbitMq(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(RabbitMqOptions.HostName)
                    .Description("RabbitMQ Host name")
                    .ConfigPath("RabbitMQ:Hostname")
                    .EnvironmentVariable("RABBITMQ_HOSTNAME")
                    .Group(RabbitMqGroup)
                )
                .RegisterOption<int>(b => b
                    .Name(RabbitMqOptions.Port)
                    .Description("RabbitMQ port")
                    .ConfigPath("RabbitMQ:Port")
                    .EnvironmentVariable("RABBITMQ_PORT")
                    .Group(RabbitMqGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(RabbitMqOptions.UserName)
                    .Description("RabbitMQ username")
                    .ConfigPath("RabbitMQ:UserName")
                    .EnvironmentVariable("RABBITMQ_USERNAME")
                    .Group(RabbitMqGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(RabbitMqOptions.Password)
                    .Description("RabbitMQ password")
                    .ConfigPath("RabbitMQ:Password")
                    .EnvironmentVariable("RABBITMQ_PASSWORD")
                    .Group(RabbitMqGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(RabbitMqOptions.VirtualHost)
                    .Description("RabbitMQ virtual host")
                    .ConfigPath("RabbitMQ:VirtualHost")
                    .EnvironmentVariable("RABBITMQ_VIRTUALHOST")
                    .Group(RabbitMqGroup)
                );
        }
    }
}