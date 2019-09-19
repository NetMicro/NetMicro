using NFlags.Commands;

namespace NetMicro.Auth.Jwt.NFlags
{
    public class AuthConfiguration : IAuthConfiguration
    {
        private readonly CommandArgs _commandArgs;

        public AuthConfiguration(CommandArgs commandArgs)
        {
            _commandArgs = commandArgs;
        }

        public string PublicKey => _commandArgs.GetOption<string>(AuthOptions.AuthPublicKey);
        public string PrivateKey => _commandArgs.GetOption<string>(AuthOptions.AuthPrivateKey);
        public string Secret => _commandArgs.GetOption<string>(AuthOptions.AuthSecret);
    }
}