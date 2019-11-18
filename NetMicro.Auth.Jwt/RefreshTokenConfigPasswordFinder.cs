using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt
{
    public class RefreshTokenConfigPasswordFinder : IPasswordFinder
    {
        private readonly char[] _password;

        public RefreshTokenConfigPasswordFinder(IAuthConfiguration authConfiguration)
        {
            _password = authConfiguration.RefreshTokenSecret.ToCharArray();
        }

        public char[] GetPassword()
        {
            return _password;
        }
    }
}