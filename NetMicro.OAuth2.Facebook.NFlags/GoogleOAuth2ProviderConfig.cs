using NFlags.Commands;

namespace NetMicro.OAuth2.Facebook.NFlags
{
    public class FacebookOAuth2ProviderConfig : IFacebookOAuth2ProviderConfig
    {
        private readonly CommandArgs _commandArgs;

        public FacebookOAuth2ProviderConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string ClientId => _commandArgs.GetOption<string>(FacebookOAuth2Options.ClientId);
        public string ClientSecret => _commandArgs.GetOption<string>(FacebookOAuth2Options.ClientSecret);
        public string RedirectUri => _commandArgs.GetOption<string>(FacebookOAuth2Options.RedirectUri);
    }
}