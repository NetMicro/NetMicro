using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NetMicro.Routing;

namespace NetMicro.Auth.Jwt.Middleware
{
    public static class MiddlewareSupportExtensions
    {
        public static void JwtAuth(this IMiddlewareSupport middlewareSupport, ITokenDecoder<JwtToken> tokenDecoder)
        {
            middlewareSupport.Use(async (context, next) =>
            {
                const string jwtHeaderPrefix = "Bearer ";

                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    await Task.Run(() => context.Response.StatusCode = HttpStatusCode.Unauthorized);
                    return;
                }

                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authorizationHeader == null || !authorizationHeader.StartsWith(jwtHeaderPrefix))
                {
                    await Task.Run(() => context.Response.StatusCode = HttpStatusCode.Unauthorized);
                    return;
                }

                var token = authorizationHeader.Substring(jwtHeaderPrefix.Length);

                try
                {
                    var payload = tokenDecoder.DecodeToken(token);

                    var tokenExpires = ExpDateTimeConverter.ToDateTime(payload.exp);

                    if (tokenExpires <= DateTime.UtcNow)
                    {
                        await Task.Run(() => context.Response.StatusCode = HttpStatusCode.Unauthorized);
                        return;
                    }

                    await next(context);
                }
                catch (Exception)
                {
                    await Task.Run(() => context.Response.StatusCode = HttpStatusCode.Unauthorized);
                }
            });
        }
    }
}