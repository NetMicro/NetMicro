using Autofac;

namespace NetMicro.Routing.Binding.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterContentParser<TContentParser>(this ContainerBuilder builder, string contentType)
            where TContentParser : IContentParser
        {
            builder.RegisterType<JsonContentParser>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ContentParserFactory<TContentParser>>()
                .WithParameter("contentType", contentType)
                .As<IContentParserFactory>()
                .InstancePerLifetimeScope();
        }
    }
}