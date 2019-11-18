using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt
{
    public class ConfigPasswordFinder : IPasswordFinder
    {
        private readonly char[] _password;

        public ConfigPasswordFinder(IAuthConfiguration authConfiguration)
        {
            _password = authConfiguration.AccessTokenSecret.ToCharArray();
        }

        public char[] GetPassword()
        {
            return _password;
        }
    }
}