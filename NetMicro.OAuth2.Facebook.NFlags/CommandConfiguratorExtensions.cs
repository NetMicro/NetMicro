using NFlags.Commands;

namespace NetMicro.OAuth2.Facebook.NFlags
{
    public static class CommandConfiguratorExtensions
    {
        private const string FacebookOAuth2Group = "OAuth2:Facebook";

        public static CommandConfigurator RegisterFacebookOAuth2Provider(this CommandConfigurator commandConfigurator)
        {
            return commandConfigurator
                .RegisterOption<string>(b => b
                    .Name(FacebookOAuth2Options.ClientId)
                    .Description("OAuth2 ClientId for Facebook provider")
                    .ConfigPath("OAuth2:Facebook:ClientId")
                    .EnvironmentVariable("OAUTH2_FACEBOOK_CLIENT_ID")
                    .Group(FacebookOAuth2Group)
                )
                .RegisterOption<string>(b => b
                    .Name(FacebookOAuth2Options.ClientSecret)
                    .Description("OAuth2 ClientId for Facebook provider")
                    .ConfigPath("OAuth2:Facebook:ClientSecret")
                    .EnvironmentVariable("OAUTH2_FACEBOOK_CLIENT_SECRET")
                    .Group(FacebookOAuth2Group)
                )
                .RegisterOption<string>(b => b
                    .Name(FacebookOAuth2Options.RedirectUri)
                    .Description("OAuth2 redirect uri for Facebook provider")
                    .ConfigPath("OAuth2:Facebook:RedirectUri")
                    .EnvironmentVariable("OAUTH2_FACEBOOK_REDIRECT_URI")
                    .Group(FacebookOAuth2Group)
                );
        }
    }
}