using System;
using System.IO;
using System.Security.Cryptography;
using Jose;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt
{
    public class RsaTokenGenerator<TToken> : ITokenGenerator<TToken>
    {
        private readonly IKeyProvider _keyProvider;
        private readonly IPasswordFinder _passwordFinder;

        public RsaTokenGenerator(IKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
        }

        public RsaTokenGenerator(IPasswordFinder passwordFinder, IKeyProvider keyProvider)
        {
            _passwordFinder = passwordFinder;
            _keyProvider = keyProvider;
        }

        public string CreateToken(TToken data)
        {
            RSAParameters rsaParams;
            using (var tr = new StringReader(_keyProvider.Key))
            {
                var pemReader = new PemReader(tr, _passwordFinder);
                if (!(pemReader.ReadObject() is AsymmetricCipherKeyPair keyPair))
                    throw new Exception("Could not read RSA private key");
                var privateRsaParams = keyPair.Private as RsaPrivateCrtKeyParameters;
                rsaParams = DotNetUtilities.ToRSAParameters(privateRsaParams);
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                return JWT.Encode(data, rsa, JwsAlgorithm.RS256);
            }
        }
    }
}