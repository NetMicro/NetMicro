using Autofac;
using Org.BouncyCastle.OpenSsl;

namespace NetMicro.Auth.Jwt.Autofac
{
    public class RsaAuthModule : Module
    {
        private const string PrivateKeyProvider = "PrivateKeyProvider";
        private const string PublicKeyProvider = "PublicKeyProvider";

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().PrivateKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(PrivateKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenGenerator<JwtToken>(
                    c.Resolve<IPasswordFinder>(),
                    c.ResolveNamed<IKeyProvider>(PrivateKeyProvider))
                )
                .As<ITokenGenerator<JwtToken>>()
                .SingleInstance();

            builder
                .Register(context => new FileKeyProvider(context.Resolve<IAuthConfiguration>().PublicKey))
                .As<IKeyProvider>()
                .Named<IKeyProvider>(PublicKeyProvider)
                .SingleInstance();

            builder
                .Register(c => new RsaTokenDecoder<JwtToken>(
                    c.Resolve<IPasswordFinder>(),
                    c.ResolveNamed<IKeyProvider>(PublicKeyProvider))
                )
                .As<ITokenDecoder<JwtToken>>()
                .SingleInstance();

            builder.RegisterType<ConfigPasswordFinder>().As<IPasswordFinder>().SingleInstance();
        }
    }
}