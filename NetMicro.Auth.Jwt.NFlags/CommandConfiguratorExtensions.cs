using NFlags.Commands;

namespace NetMicro.Auth.Jwt.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string AuthorizationGroup = "Authorization";

        public static CommandConfigurator RegisterAuth(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterRefreshToken()
                .RegisterAccessTokenRead()
                .RegisterAccessTokenWrite();
        }

        public static CommandConfigurator RegisterAccessTokenRead(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AccessTokenPublicKey)
                    .Description("Public key used to decode access token")
                    .ConfigPath("Auth:AccessToken:PublicKey")
                    .EnvironmentVariable("ACCESS_TOKEN_PUBLIC_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AccessTokenSecret)
                    .Description("Secret for access token keys")
                    .ConfigPath("Auth:AccessToken:Secret")
                    .EnvironmentVariable("ACCESS_TOKEN_SECRET")
                    .Group(AuthorizationGroup)
                );
        }

        private static CommandConfigurator RegisterRefreshToken(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.RefreshTokenPublicKey)
                    .Description("Public key used to decode refresh token")
                    .ConfigPath("Auth:RefreshToken:PublicKey")
                    .EnvironmentVariable("REFRESH_TOKEN_PUBLIC_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.RefreshTokenPrivateKey)
                    .Description("Private key used to generate refresh token")
                    .ConfigPath("Auth:RefreshToken:PrivateKey")
                    .EnvironmentVariable("REFRESH_TOKEN_PRIVATE_KEY")
                    .Group(AuthorizationGroup)
                )
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.RefreshTokenSecret)
                    .Description("Secret for refresh token keys")
                    .ConfigPath("Auth:RefreshToken:Secret")
                    .EnvironmentVariable("REFRESH_TOKEN_SECRET")
                    .Group(AuthorizationGroup)
                );
        }

        private static CommandConfigurator RegisterAccessTokenWrite(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(AuthOptions.AccessTokenPrivateKey)
                    .Description("Private key used to generate access token")
                    .ConfigPath("Auth:AccessToken:PrivateKey")
                    .EnvironmentVariable("ACCESS_TOKEN_PRIVATE_KEY")
                    .Group(AuthorizationGroup)
                );
        }
    }
}