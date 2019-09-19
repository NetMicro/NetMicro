using Autofac;
using NetMicro.Routing;

namespace NetMicro.Controllers.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterContext(this ContainerBuilder builder, Context context)
        {
            builder.RegisterInstance(context);
            builder.RegisterInstance(context.Request);
            builder.RegisterInstance(context.Response);
            builder.RegisterInstance(context.SelectedRoute);
        }
    }
}