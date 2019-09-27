using System;
using System.Linq;
using System.Net.Mime;
using NetMicro.Http;
using NetMicro.Routing;

namespace NetMicro.ErrorHandling
{
    public static class MiddlewareSupportExtensions
    {
        public static void RestHandleExceptions(this IMiddlewareSupport middlewareSupport, ExceptionStatusCodeMapper mapper)
        {
            middlewareSupport.Use(async (context, next) =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception e)
                {
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
                                await context.Response.SetJsonResponse(e, mapper);
                                return;
                            case MediaTypeNames.Text.Html:
                                await context.Response.SetHtmlResponse(e);
                                return;
                        }
                    }

                    await context.Response.SetHtmlResponse(e);
                }
            });
        }
    }
}