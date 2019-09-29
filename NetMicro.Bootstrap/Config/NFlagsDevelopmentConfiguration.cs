using NFlags.Commands;

namespace NetMicro.Bootstrap.Config
{
    public class NFlagsDevelopmentConfiguration : IDevelopmentConfiguration
    {
        private readonly CommandArgs _commandArgs;

        public NFlagsDevelopmentConfiguration(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public bool DisableSecurity => _commandArgs.GetFlag(DevelopmentFlags.DisableSecurity);
    }
}