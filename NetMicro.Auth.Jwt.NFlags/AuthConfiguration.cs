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

        public bool DisableAuth => _commandArgs.GetFlag(AuthOptions.DisableAuth);
        public string AccessTokenPublicKey => _commandArgs.GetOption<string>(AuthOptions.AccessTokenPublicKey);
        public string AccessTokenPrivateKey => _commandArgs.GetOption<string>(AuthOptions.AccessTokenPrivateKey);
        public string AccessTokenSecret => _commandArgs.GetOption<string>(AuthOptions.AccessTokenSecret);

        public string RefreshTokenPublicKey => _commandArgs.GetOption<string>(AuthOptions.RefreshTokenPublicKey);
        public string RefreshTokenPrivateKey => _commandArgs.GetOption<string>(AuthOptions.RefreshTokenPrivateKey);
        public string RefreshTokenSecret => _commandArgs.GetOption<string>(AuthOptions.RefreshTokenSecret);
    }
}