using System.Threading.Tasks;
using NetMicro.Routing;

namespace NetMicro.Controllers
{
    public interface IRequestControllerExecutor<TRequestController>
        where TRequestController : IRequestController
    {
        Task Execute(Context context);
    }
}