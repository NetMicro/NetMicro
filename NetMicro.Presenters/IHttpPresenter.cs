using System.Net;
using System.Threading.Tasks;

namespace NetMicro.Presenters
{
    public interface IHttpPresenter
    {
        Task Present(object data);
        Task Present(object data, HttpStatusCode statusCode);
        Task PresentError(HttpStatusCode statusCode, string error, params string[] parameters);
    }
}