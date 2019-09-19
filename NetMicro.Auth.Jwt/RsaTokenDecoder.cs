using System;
using System.IO;
using System.Security.Cryptography;
using Jose;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt
{
    public class RsaTokenDecoder<TToken> : ITokenDecoder<TToken>
    {
        private readonly IKeyProvider _keyProvider;
        private readonly IPasswordFinder _passwordFinder;

        public RsaTokenDecoder(IKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
        }

        public RsaTokenDecoder(IPasswordFinder passwordFinder, IKeyProvider keyProvider)
        {
            _passwordFinder = passwordFinder;
            _keyProvider = keyProvider;
        }

        public TToken DecodeToken(string token)
        {
            RSAParameters rsaParams;

            using (var tr = new StringReader(_keyProvider.Key))
            {
                var pemReader = new PemReader(tr, _passwordFinder);
                if (!(pemReader.ReadObject() is RsaKeyParameters publicKeyParams))
                    throw new Exception("Could not read RSA public key");
                rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParams);
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                return JWT.Decode<TToken>(token, rsa, JwsAlgorithm.RS256);
            }
        }
    }
}