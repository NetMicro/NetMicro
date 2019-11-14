using System;

namespace NetMicro.Routing.Extensions.Cors
{
    public static class HandleCorsOptionsMiddleware
    {
        public static void EnableCorsOptionRequestHandling(this IRouter router,
            Action<CorsOptions> setOptions = null)
        {
            router.Use(async (context, next) =>
            {
                if (context.Request.Method == "options")
                    context.Response.SetCorsHeaders(CorsOptions.GetCorsOptions(setOptions));

                await next(context);
            });
        }

        public static void EnableCorsOptionRequestHandling(this GroupRoute route,
            Action<CorsOptions> setOptions = null)
        {
            route.Use(async (context, next) =>
            {
                if (context.Request.Method == "options")
                    context.Response.SetCorsHeaders(CorsOptions.GetCorsOptions(setOptions));

                await next(context);
            });
        }
    }
}