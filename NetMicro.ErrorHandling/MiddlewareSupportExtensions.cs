using System;
using System.Linq;
using System.Net.Mime;
using Microsoft.Extensions.Logging;
using NetMicro.Http;
using NetMicro.Routing;

namespace NetMicro.ErrorHandling
{
    public static class MiddlewareSupportExtensions
    {
        public static void UseRestErrorHandling(
            this IMiddlewareSupport middlewareSupport,
            IErrorHandlingConfiguration configuration,
            ExceptionStatusCodeMapper mapper,
            ILogger<ErrorHandlingModule> logger)
        {

            middlewareSupport.Use(async (context, next) =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception e)
                {
                    logger.LogError(e, $"Error during processing request: {context.Request.Method} {context.Request.Url}");
                    var mimeTypes = context.Request.GetResponseMimeTypesPriority(new[]
                    {
                        MediaTypeNames.Application.Json,
                        MediaTypeNames.Text.Html
                    });

                    if (mimeTypes != null)
                    {
                        switch (mimeTypes.FirstOrDefault())
                        {
                            case MediaTypeNames.Application.Json:
                                await context.Response.SetJsonResponse(e, mapper, configuration);
                                return;
                            case MediaTypeNames.Text.Html:
                                await context.Response.SetHtmlResponse(e, configuration);
                                return;
                        }
                    }

                    await context.Response.SetHtmlResponse(e, configuration);
                }
            });
        }
    }
}