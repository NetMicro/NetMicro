using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt
{
    public class AccessTokenConfigPasswordFinder : IPasswordFinder
    {
        private readonly char[] _password;

        public AccessTokenConfigPasswordFinder(IAuthConfiguration authConfiguration)
        {
            _password = authConfiguration.AccessTokenSecret.ToCharArray();
        }

        public char[] GetPassword()
        {
            return _password;
        }
    }
}