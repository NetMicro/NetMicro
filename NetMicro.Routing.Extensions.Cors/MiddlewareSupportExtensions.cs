using System;

namespace NetMicro.Routing.Extensions.Cors
{
    public static class MiddlewareSupportExtensions
    {
        public static void UseCors(this IMiddlewareSupport middleware, Action<CorsOptions> setOptions = null)
        {
            middleware.Use(async (context, next) =>
            {
                context.Response.SetCorsHeaders(CorsOptions.GetCorsOptions(setOptions));
                await next(context);
            });
        }
    }
}