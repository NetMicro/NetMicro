using NFlags.Commands;

namespace NetMicro.OAuth2.Google.NFlags
{
    public class GoogleOAuth2ProviderConfig : IGoogleOAuth2ProviderConfig
    {
        private readonly CommandArgs _commandArgs;

        public GoogleOAuth2ProviderConfig(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string ClientId => _commandArgs.GetOption<string>(GoogleOAuth2Options.ClientId);
        public string ClientSecret => _commandArgs.GetOption<string>(GoogleOAuth2Options.ClientSecret);
        public string RedirectUri => _commandArgs.GetOption<string>(GoogleOAuth2Options.RedirectUri);
    }
}