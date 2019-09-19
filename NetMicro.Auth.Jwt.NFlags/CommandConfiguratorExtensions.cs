using NFlags.Commands;

namespace NetMicro.Auth.Jwt.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string AuthorizationGroup = "Authorization";

        public static CommandConfigurator RegisterAuth(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AuthPublicKey)
                    .Description("Public key used to decrypt authentication token")
                    .ConfigPath("Auth:PublicKey")
                    .EnvironmentVariable("AUTH_PUBLIC_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AuthPrivateKey)
                    .Description("Private key used to generate authentication token")
                    .ConfigPath("Auth:PrivateKey")
                    .EnvironmentVariable("AUTH_PRIVATE_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AuthSecret)
                    .Description("Secret key for private key")
                    .ConfigPath("Auth:Secret")
                    .EnvironmentVariable("AUTH_SECRET")
                    .Group(AuthorizationGroup)
                );
        }

        public static CommandConfigurator RegisterAuthRO(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AuthPublicKey)
                    .Description("Public key used to decrypt authentication token")
                    .ConfigPath("Auth:PublicKey")
                    .EnvironmentVariable("AUTH_PUBLIC_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AuthSecret)
                    .Description("Secret key for private key")
                    .ConfigPath("Auth:Secret")
                    .EnvironmentVariable("AUTH_SECRET")
                    .Group(AuthorizationGroup)
                );
        }
    }
}