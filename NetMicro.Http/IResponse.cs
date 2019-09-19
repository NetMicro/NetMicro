using System.Net;
using System.Threading.Tasks;

namespace NetMicro.Http
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; set; }

        Task WriteBodyAsync(string body);
        void SetHeader(string header, string value);
    }
}