using System;
using System.Net.Mime;
using System.Threading.Tasks;
using NetMicro.Http;
using Newtonsoft.Json;

namespace NetMicro.ErrorHandling
{
    public static class JsonErrorResponse
    {
        private const string SomethingWentWrong = "SOMETHING_WENT_WRONG";
        public static async Task SetJsonResponse(
            this IResponse response,
            Exception e,
            ExceptionStatusCodeMapper exceptionStatusCodesMapper,
            IErrorHandlingConfiguration configuration)
        {
            var responseStatusCode = exceptionStatusCodesMapper.GetStatusCode(e);
            response.StatusCode = responseStatusCode;
            response.SetHeader("Content-Type", MediaTypeNames.Application.Json);
            var resp = new ErrorResponse
            {
                Status = (int) responseStatusCode,
                Error = SomethingWentWrong
            };

            if (configuration.ShowCallStack)
                resp.Exception = e;
                
            await response.WriteBodyAsync(Body(resp));
        }

        private static string Body(ErrorResponse e)
        {
            return JsonConvert.SerializeObject(e);
        }
    }
}