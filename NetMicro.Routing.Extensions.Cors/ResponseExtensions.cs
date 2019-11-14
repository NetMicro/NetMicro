using NetMicro.Http;

namespace NetMicro.Routing.Extensions.Cors
{
    public static class ResponseExtensions
    {
        public static void SetCorsHeaders(this IResponse response, CorsOptions corsOptions)
        {
            if (corsOptions.AllowOrigin.IsSet)
                response.SetHeader("Access-Control-Allow-Origin", corsOptions.AllowOrigin.Values);

            if (corsOptions.AllowCredentials.IsSet)
                response.SetHeader("Access-Control-Allow-Credentials", corsOptions.AllowCredentials.Values);

            if (corsOptions.AllowMethods.IsSet)
                response.SetHeader("Access-Control-Allow-Methods", corsOptions.AllowMethods.Values);

            if (corsOptions.AllowHeaders.IsSet)
                response.SetHeader("Access-Control-Allow-Headers", corsOptions.AllowHeaders.Values);
        }
    }
}