using NFlags.Commands;

namespace NetMicro.Bootstrap
{
    public static class CommandConfiguratorExtensions
    {
        private const string DevelopmentGroup = "Development";

        public static CommandConfigurator RegisterDevelopment(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(DevelopmentFlags.DisableSecurity)
                    .Description("Disables security")
                    .ConfigPath("Development:DisableSecurity")
                    .EnvironmentVariable("DEVELOPMENT_DISABLE_SECURITY")
                    .Group(DevelopmentGroup)
                )
                .RegisterFlag(b => b
                    .Name(DevelopmentFlags.ErrorHandling)
                    .Description("Enable error handling")
                    .ConfigPath("Development:ErrorHandling")
                    .EnvironmentVariable("DEVELOPMENT_ERROR_HANDLING")
                    .Group(DevelopmentGroup)
                );
        }
    }
}