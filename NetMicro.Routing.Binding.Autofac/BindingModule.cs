using Autofac;

namespace NetMicro.Routing.Binding.Autofac
{
    public class BindingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ContentParserResolver>()
                .InstancePerLifetimeScope();

            builder
                .Register(componentContext => componentContext.Resolve<ContentParserResolver>().Create())
                .InstancePerLifetimeScope();
        }
    }
}