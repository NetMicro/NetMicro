using System;
using System.Threading.Tasks;

namespace NetMicro.Routing.Extensions.Cors
{
    public static class HandleCorsOptionsMiddleware
    {
        public static void EnableCorsOptionsRequestHandling(this IRouteConfigurator router,
            Action<CorsOptions> setOptions = null)
        {
            router.Options("cors_preflight", "*",context =>
            {
                return Task.Run(() =>
                    context.Response.SetCorsHeaders(CorsOptions.GetCorsOptions(setOptions)));
            });

            router.Options("cors_preflight", "/",context =>
            {
                return Task.Run(() =>
                    context.Response.SetCorsHeaders(CorsOptions.GetCorsOptions(setOptions)));
            });
        }
    }
}