using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.ErrorHandling
{
    public static class HtmlErrorResponse
    {
        public static async Task SetHtmlResponse(this IResponse response, Exception e)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.SetHeader("Content-Type", MediaTypeNames.Text.Html);
            await response.WriteBodyAsync(Body(e));
        }

        private static string Body(Exception e)
        {
            return $@"<!doctype html>
    <html lang=""en"">
        <head>
            <meta charset=""utf-8"">
            <title>NetMicro Error</title>
            <meta name=""description"" content=""The HTML5 Herald"">
        </head>
        <body>
            <h1>Exception:</h1>
            {GetDeepExceptionHtml(e)}
        </body>
    </html>";
        }

        private static string GetDeepExceptionHtml(Exception e)
        {
            var exceptions = "";
            while (e != null)
            {
                exceptions += GetExceptionHtml(e);
                e = e.InnerException;
            }

            return exceptions;
        }

        private static string GetExceptionHtml(Exception e)
        {
            return $@"
            <p>{e.GetType().FullName}<p>
            <p>{e.Message}</p>
            <pre>{e.StackTrace.Replace(Environment.NewLine, "<br>")}</pre>";
        }
    }
}