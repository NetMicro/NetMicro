using Autofac;

namespace NetMicro.OAuth2.Google.NFlags.Autofac
{
    public class GoogleOAuth2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(GoogleOAuth2Provider<>))
                .As(typeof(IOAuth2Provider<>))
                .InstancePerDependency();

            builder
                .RegisterType<GoogleOAuth2ProviderConfig>()
                .As<IGoogleOAuth2ProviderConfig>()
                .SingleInstance();
        }
    }
}