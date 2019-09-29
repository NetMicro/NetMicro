using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.ErrorHandling
{
    public static class HtmlErrorResponse
    {
        public static async Task SetHtmlResponse(
            this IResponse response,
            Exception e,
            IErrorHandlingConfiguration configuration)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.SetHeader("Content-Type", MediaTypeNames.Text.Html);
            await response.WriteBodyAsync(new BodyBuilder(configuration).Body(e));
        }

        private class BodyBuilder
        {
            private readonly IErrorHandlingConfiguration _configuration;

            public BodyBuilder(IErrorHandlingConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string Body(Exception exception)
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
            {GetDeepExceptionHtml(exception)}
        </body>
    </html>";
            }

            private string GetDeepExceptionHtml(Exception e)
            {
                var exceptions = "";
                while (e != null)
                {
                    exceptions += GetExceptionHtml(e);
                    e = e.InnerException;
                }

                return exceptions;
            }

            private string GetExceptionHtml(Exception e)
            {
                var html = $@"
                <p>{e.GetType().FullName}<p>
                <p>{e.Message}</p>";

                if (_configuration.ShowCallStack)
                    html += $@"
                <pre>{e.StackTrace.Replace(Environment.NewLine, "<br>")}</pre>";

                return html;
            }
        }
    }
}