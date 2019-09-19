using Autofac;

namespace NetMicro.Presenters.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterPresenter<TPresenter>(this ContainerBuilder builder, string contentType)
            where TPresenter : IHttpPresenter
        {
            builder.RegisterType<JsonHttpPresenter>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<PresenterFactory<TPresenter>>()
                .WithParameter("contentType", contentType)
                .As<IPresenterFactory>()
                .InstancePerLifetimeScope();
        }
    }
}