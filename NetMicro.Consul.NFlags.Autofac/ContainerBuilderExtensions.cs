using Autofac;

namespace NetMicro.Consul.NFlags.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void UseConsul(this ContainerBuilder builder)
        {
            builder.RegisterModule<ConsulExtensionModule>();
        }
    }
}