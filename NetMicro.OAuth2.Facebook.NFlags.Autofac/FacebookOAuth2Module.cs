using Autofac;

namespace NetMicro.OAuth2.Facebook.NFlags.Autofac
{
    public class FacebookOAuth2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(FacebookOAuth2Provider<>))
                .As(typeof(IOAuth2Provider<>))
                .InstancePerDependency();

            builder
                .RegisterType<FacebookOAuth2ProviderConfig>()
                .As<IFacebookOAuth2ProviderConfig>()
                .SingleInstance();
        }
    }
}