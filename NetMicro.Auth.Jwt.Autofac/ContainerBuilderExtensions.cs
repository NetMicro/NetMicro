using System;
using Autofac;
using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public const string TokenGenerator = "TokenGenerator";
        public const string TokenDecoder = "TokenDecoder";

        private const string TokenPrivateKeyProvider = "TokenPrivateKeyProvider";
        private const string TokenPublicKeyProvider = "TokenPublicKeyProvider";
        private const string TokenConfigPasswordFinder = "TokenConfigPasswordFinder";

        public static ContainerBuilder UseJwtAuth(this ContainerBuilder builder)
        {
            builder.RegisterModule<RsaAuthModule>();
            return builder;
        }

        public static ContainerBuilder RegisterToken<TPasswordFinder>(
            this ContainerBuilder builder,
            string tokenName,
            Func<IComponentContext, string> publicKeyProvider,
            Func<IComponentContext, string> privateKeyProvider
            )
        {
            builder
                .Register(context => new FileKeyProvider(privateKeyProvider(context)))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(tokenName + TokenPrivateKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenGenerator<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(tokenName + TokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(tokenName + TokenPrivateKeyProvider)
                ))
                .As<ITokenGenerator<JwtToken>>()
                .Named<ITokenGenerator<JwtToken>>(tokenName + TokenGenerator)
                .SingleInstance();

            builder
                .Register(context => new FileKeyProvider(publicKeyProvider(context)))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(tokenName + TokenPublicKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenDecoder<JwtToken>(
                    c.ResolveNamed<IPasswordFinder>(tokenName + TokenConfigPasswordFinder),
                    c.ResolveNamed<IKeyProvider>(tokenName + TokenPublicKeyProvider)
                ))
                .As<ITokenDecoder<JwtToken>>()
                .Named<ITokenDecoder<JwtToken>>(tokenName + TokenDecoder)
                .SingleInstance();

            builder
                .RegisterType<TPasswordFinder>()
                .As<IPasswordFinder>().SingleInstance()
                .Named<IPasswordFinder>(tokenName + TokenConfigPasswordFinder);

            return builder;
        }
    }
}