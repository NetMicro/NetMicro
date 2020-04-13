using NFlags.Commands;

namespace NetMicro.ErrorHandling.NFlags
{
    public class ErrorHandlingConfiguration : IErrorHandlingConfiguration
    {
        private readonly CommandArgs _commandArgs;

        public ErrorHandlingConfiguration(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public bool ShowCallStack => _commandArgs.GetFlag(ErrorHandlingOptions.ShowCallStack);
    }
}