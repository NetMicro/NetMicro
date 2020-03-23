using Autofac;

namespace NetMicro.OAuth2.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseOAuth2(this ContainerBuilder builder)
        {
            builder.RegisterModule<OAuth2Module>();
        }
    }
}