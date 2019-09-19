using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using NetMicro.Http;

namespace NetMicro.Routing.Owin
{
    public static class OwinRouter
    {
        public static IApplicationBuilder UseNetMicro(this IApplicationBuilder builder, Action<IRouter> configureRouter)
        {
            return UseNetMicro(builder, new Configuration
            {
                Bootstrapper = new Bootstrapper(configureRouter)
            });
        }

        public static IApplicationBuilder UseNetMicro(this IApplicationBuilder builder, Configuration configuration)
        {
            var router = new Router();
            configuration.Bootstrapper.Configure(router);
            builder.Run(async context =>
            {
                await router.HandleAsync(
                    new Request(
                        new Url(
                            context.Request.Method,
                            context.Request.Scheme,
                            context.Request.Host.Host,
                            context.Request.Host.Port,
                            context.Request.Path,
                            context.Request.QueryString.Value
                        ),
                        context.Request.Headers.ToDictionary(pair => pair.Key, pair => pair.Value.Select(s => s)),
                        context.Request.Body
                    ),
                    new Response(context)
                );
            });

            return builder;
        }
    }
}