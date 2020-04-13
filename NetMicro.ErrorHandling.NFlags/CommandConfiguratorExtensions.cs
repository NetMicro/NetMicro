using NFlags.Commands;

namespace NetMicro.ErrorHandling.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string ErrorHandlingGroup = "ErrorHandling";

        public static CommandConfigurator RegisterErrorHandling(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(ErrorHandlingOptions.ShowCallStack)
                    .Description("Enables call stack printing when handling errors.")
                    .ConfigPath("ErrorHandling:ShowCallStack")
                    .EnvironmentVariable("DEVELOPMENT_SHOW_CALL_STACK")
                    .Group(ErrorHandlingGroup)
                );
        }
    }
}