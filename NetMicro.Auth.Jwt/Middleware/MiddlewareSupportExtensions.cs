using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetMicro.Http;
using NetMicro.Routing;

namespace NetMicro.Auth.Jwt.Middleware
{
    public static class MiddlewareSupportExtensions
    {
        public static void JwtAuth(this IMiddlewareSupport middlewareSupport, ITokenDecoder<JwtToken> tokenDecoder,
            ILogger logger, Func<Request, bool> excludeFilter = null)
        {
            middlewareSupport.Use(async (context, next) =>
            {
                if (excludeFilter != null && excludeFilter(context.Request))
                {
                    await next(context);
                    return;
                }

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

                    context.Extensions.Register(new Session.Session(payload.username));
                }
                catch (Exception e)
                {
                    logger.LogError(e, $"Request {context.Request.Method} {context.Request.Url} unauthorized!");
                    await Task.Run(() => context.Response.StatusCode = HttpStatusCode.Unauthorized);
                    return;
                }

                await next(context);
            });
        }
    }
}