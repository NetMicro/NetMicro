using Autofac;

namespace NetMicro.Auth.Jwt.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseJwtAuth(this ContainerBuilder builder)
        {
            builder.RegisterModule<RsaAuthModule>();
        }
    }
}