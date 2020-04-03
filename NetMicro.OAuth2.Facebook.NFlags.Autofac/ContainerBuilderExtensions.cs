using Autofac;

namespace NetMicro.OAuth2.Facebook.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseFacebookOAuth2<TProfile, TProfileParser>(this ContainerBuilder builder)
            where TProfileParser : IProfileParser<TProfile>
        {
            builder.RegisterModule<FacebookOAuth2Module>();

            builder
                .RegisterType<TProfileParser>()
                .As<IProfileParser<TProfile>>();
        }
    }
}