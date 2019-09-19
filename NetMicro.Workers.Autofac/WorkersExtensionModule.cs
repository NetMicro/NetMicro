using Autofac;

namespace NetMicro.Workers.Autofac
{
    public class WorkersExtensionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<WorkersExtension>()
                .As<IExtension>()
                .SingleInstance();
        }
    }
}