using System.Threading.Tasks;
using NetMicro.Routing;

namespace NetMicro.Controllers
{
    public class Controller<TRequestController> where TRequestController : IRequestController
    {
        private readonly IRequestControllerExecutor<TRequestController> _controllerExecutor;

        public Controller(IRequestControllerExecutor<TRequestController> controllerExecutor)
        {
            _controllerExecutor = controllerExecutor;
        }

        public async Task Execute(Context context)
        {
            await _controllerExecutor.Execute(context);
        }
    }
}