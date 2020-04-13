using NFlags.Commands;

namespace NetMicro.Auth.Jwt.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string AuthorizationGroup = "Authorization";

        public static CommandConfigurator RegisterAuth(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterFlag(b => b
                    .Name(AuthOptions.DisableAuth)
                    .Description("Disables auth")
                    .ConfigPath("Auth:DisableAuth")
                    .EnvironmentVariable("DEVELOPMENT_DISABLE_AUTH")
                    .Group(AuthorizationGroup)
                )
                .RegisterToken(AuthOptions.AccessTokenName)
                .RegisterToken(AuthOptions.RefreshTokenName);

        }

        public static CommandConfigurator RegisterToken(this CommandConfigurator commandConfigurator, string tokenName)
        {
            return commandConfigurator
                .RegisterTokenRead(tokenName)
                .RegisterTokenWrite(tokenName);
        }

        public static CommandConfigurator RegisterTokenWrite(this CommandConfigurator commandConfigurator, string tokenName)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(tokenName.ToLower() + AuthOptions.TokenPrivateKeySuffix)
                    .Description($"Private key used to generate {tokenName.ToLower()} token")
                    .ConfigPath($"Auth:{tokenName}Token:PrivateKey")
                    .EnvironmentVariable($"{tokenName.ToUpper()}_TOKEN_PRIVATE_KEY")
                    .Group(AuthorizationGroup)
                );
        }

        public static CommandConfigurator RegisterTokenRead(this CommandConfigurator commandConfigurator, string tokenName)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(tokenName.ToLower() + AuthOptions.TokenPublicKeySuffix)
                    .Description($"Public key used to decode {tokenName.ToLower()} token")
                    .ConfigPath($"Auth:{tokenName}Token:PublicKey")
                    .EnvironmentVariable($"{tokenName.ToUpper()}_TOKEN_PUBLIC_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(tokenName.ToLower() + AuthOptions.TokenSecretSuffix)
                    .Description($"Secret for {tokenName.ToLower()} token keys")
                    .ConfigPath($"Auth:{tokenName}Token:Secret")
                    .EnvironmentVariable($"{tokenName.ToUpper()}_TOKEN_SECRET")
                    .Group(AuthorizationGroup)
                );
        }
    }
}