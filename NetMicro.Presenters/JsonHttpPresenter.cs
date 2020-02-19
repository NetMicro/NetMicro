using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using NetMicro.Http;
using Newtonsoft.Json;

namespace NetMicro.Presenters
{
    public class JsonHttpPresenter : IHttpPresenter
    {
        private readonly IResponse _response;

        public JsonHttpPresenter(IResponse response)
        {
            _response = response;
        }

        public async Task Present(object data)
        {
            await Present(data, HttpStatusCode.OK);
        }

        public async Task Present(object data, HttpStatusCode statusCode)
        {
            _response.StatusCode = statusCode;
            if (data != null)
            {
                _response.SetHeader("Content-Type", MediaTypeNames.Application.Json);
                await _response.WriteBodyAsync(JsonConvert.SerializeObject(data));
            }
        }
    }
}