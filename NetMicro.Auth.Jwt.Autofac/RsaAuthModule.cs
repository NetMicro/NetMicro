using Autofac;
using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt.Autofac
{
    public class RsaAuthModule : Module
    {
        public const string AccessTokenGenerator = "AccessTokenGenerator";
        public const string AccessTokenDecoder = "AccessTokenDecoder";

        public const string RefreshTokenGenerator = "RefreshTokenGenerator";
        public const string RefreshTokenDecoder = "RefreshTokenDecoder";

        private const string AccessTokenPrivateKeyProvider = "AccessTokenPrivateKeyProvider";
        private const string AccessTokenPublicKeyProvider = "AccessTokenPublicKeyProvider";
        private const string AccessTokenSecretProvider = "AccessTokenSecretProvider";
        private const string AccessTokenConfigPasswordFinder = "AccessTokenConfigPasswordFinder";

        private const string RefreshTokenPrivateKeyProvider = "RefreshTokenPrivateKeyProvider";
        private const string RefreshTokenPublicKeyProvider = "RefreshTokenPublicKeyProvider";
        private const string RefreshTokenSecretProvider = "RefreshTokenSecretProvider";
        private const string RefreshTokenConfigPasswordFinder = "AccessTokenConfigPasswordFinder";

        protected override void Load(ContainerBuilder builder)
        {
            RegisterAccessToken(builder);
            RegisterRefreshToken(builder);
        }

        private static void RegisterAccessToken(ContainerBuilder builder)
        {
            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().AccessTokenPrivateKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(AccessTokenPrivateKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenGenerator<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(AccessTokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(AccessTokenPrivateKeyProvider)
                ))
                .As<ITokenGenerator<JwtToken>>()
                .Named<ITokenGenerator<JwtToken>>(AccessTokenGenerator)
                .SingleInstance();

            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().AccessTokenPublicKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(AccessTokenPublicKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenDecoder<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(AccessTokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(AccessTokenPublicKeyProvider)
                ))
                .As<ITokenDecoder<JwtToken>>()
                .Named<ITokenDecoder<JwtToken>>(AccessTokenDecoder)
                .SingleInstance();

            builder
                .RegisterType<AccessTokenConfigPasswordFinder>()
                .As<IPasswordFinder>().SingleInstance()
                .Named<IKeyProvider>(AccessTokenConfigPasswordFinder);
        }

        private static void RegisterRefreshToken(ContainerBuilder builder)
        {
            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().RefreshTokenPrivateKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(RefreshTokenPrivateKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenGenerator<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(RefreshTokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(RefreshTokenPrivateKeyProvider)
                ))
                .As<ITokenGenerator<JwtToken>>()
                .Named<ITokenGenerator<JwtToken>>(RefreshTokenGenerator)
                .SingleInstance();

            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().RefreshTokenPublicKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(RefreshTokenPublicKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenDecoder<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(RefreshTokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(RefreshTokenPublicKeyProvider)
                ))
                .As<ITokenDecoder<JwtToken>>()
                .Named<ITokenDecoder<JwtToken>>(RefreshTokenDecoder)
                .SingleInstance();

            builder
                .RegisterType<RefreshTokenConfigPasswordFinder>()
                .As<IPasswordFinder>().SingleInstance()
                .Named<IKeyProvider>(RefreshTokenConfigPasswordFinder);
        }
    }
}