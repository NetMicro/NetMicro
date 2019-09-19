using Autofac;
using NetMicro.Consul;
using NetMicro.Consul.NFlags;

namespace NetMicro.Bootstrap.Modules
{
    public class ConsulExtensionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ConsulConfiguration>()
                .As<IConsulConfiguration>()
                .SingleInstance();

            builder
                .RegisterType<ConsulExtension>()
                .As<IExtension>()
                .SingleInstance();
        }
    }
}