using Autofac;

namespace NetMicro.OAuth2.Autofac
{
    public class OAuth2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(OAuth2ProviderResolver<>))
                .As(typeof(OAuth2.IOAuth2ProviderResolver<>))
                .SingleInstance();
        }
    }
}