using System;
using System.Net.Mime;
using System.Threading.Tasks;
using NetMicro.Http;
using Newtonsoft.Json;

namespace NetMicro.ErrorHandling
{
    public static class JsonErrorResponse
    {
        public static async Task SetJsonResponse(
            this IResponse response,
            Exception e,
            ExceptionStatusCodeMapper exceptionStatusCodesMapper,
            IErrorHandlingConfiguration configuration)
        {
            response.StatusCode = exceptionStatusCodesMapper.GetStatusCode(e);
            response.SetHeader("Content-Type", MediaTypeNames.Application.Json);
            if (configuration.ShowCallStack)
                await response.WriteBodyAsync(Body(e));
        }

        private static string Body(Exception e)
        {
            return JsonConvert.SerializeObject(e);
        }
    }
}