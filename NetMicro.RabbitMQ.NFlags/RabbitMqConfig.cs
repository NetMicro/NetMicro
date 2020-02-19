using NFlags.Commands;

namespace NetMicro.RabbitMQ.NFlags
{
    public class RabbitMqConfig : IRabbitMqConfig
    {
        private readonly CommandArgs _commandArgs;

        public RabbitMqConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string HostName  => _commandArgs.GetOption<string>(RabbitMqOptions.HostName);
        public int Port  => _commandArgs.GetOption<int>(RabbitMqOptions.Port);
        public string UserName  => _commandArgs.GetOption<string>(RabbitMqOptions.UserName);
        public string Password  => _commandArgs.GetOption<string>(RabbitMqOptions.Password);
        public string VirtualHost  => _commandArgs.GetOption<string>(RabbitMqOptions.VirtualHost);
    }
}