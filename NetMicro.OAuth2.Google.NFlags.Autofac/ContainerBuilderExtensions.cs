using Autofac;

namespace NetMicro.OAuth2.Google.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseGoogleOAuth2<TProfile, TProfileParser>(this ContainerBuilder builder)
            where TProfileParser : IProfileParser<TProfile>
        {
            builder.RegisterModule<GoogleOAuth2Module>();

            builder
                .RegisterType<TProfileParser>()
                .As<IProfileParser<TProfile>>();
        }
    }
}