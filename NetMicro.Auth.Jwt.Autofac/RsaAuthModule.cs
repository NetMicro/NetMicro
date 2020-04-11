using Autofac;

namespace NetMicro.Auth.Jwt.Autofac
{
    public class RsaAuthModule : Module
    {
        public const string Access = "Access";
        public const string Refresh = "Refresh";

        public const string AccessTokenGenerator = Access + ContainerBuilderExtensions.TokenGenerator;
        public const string AccessTokenDecoder = Access + ContainerBuilderExtensions.TokenDecoder;

        public const string RefreshTokenGenerator = Refresh + ContainerBuilderExtensions.TokenGenerator;
        public const string RefreshTokenDecoder = Refresh + ContainerBuilderExtensions.TokenDecoder;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterToken<AccessTokenConfigPasswordFinder>(
                Access,
                context => context.Resolve<IAuthConfiguration>().AccessTokenPublicKey,
                context => context.Resolve<IAuthConfiguration>().AccessTokenPrivateKey
            );

            builder.RegisterToken<RefreshTokenConfigPasswordFinder>(
                Refresh,
                context => context.Resolve<IAuthConfiguration>().RefreshTokenPublicKey,
                context => context.Resolve<IAuthConfiguration>().RefreshTokenPrivateKey
            );
        }
    }
}