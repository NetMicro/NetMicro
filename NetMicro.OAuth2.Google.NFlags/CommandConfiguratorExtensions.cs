using NFlags.Commands;

namespace NetMicro.OAuth2.Google.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string GoogleOAuth2Group = "OAuth2:Google";

        public static CommandConfigurator RegisterGoogleOAuth2Provider(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(GoogleOAuth2Options.ClientId)
                    .Description("OAuth2 ClientId for Google provider")
                    .ConfigPath("OAuth2:Google:ClientId")
                    .EnvironmentVariable("OAUTH2_GOOGLE_CLIENT_ID")
                    .Group(GoogleOAuth2Group)
                )
                .RegisterOption<string>(b => b
                    .Name(GoogleOAuth2Options.ClientSecret)
                    .Description("OAuth2 ClientId for Google provider")
                    .ConfigPath("OAuth2:Google:ClientSecret")
                    .EnvironmentVariable("OAUTH2_GOOGLE_CLIENT_SECRET")
                    .Group(GoogleOAuth2Group)
                )
                .RegisterOption<string>(b => b
                    .Name(GoogleOAuth2Options.RedirectUri)
                    .Description("OAuth2 redirect uri for Google provider")
                    .ConfigPath("OAuth2:Google:RedirectUri")
                    .EnvironmentVariable("OAUTH2_GOOGLE_REDIRECT_URI")
                    .Group(GoogleOAuth2Group)
                );
        }
    }
}