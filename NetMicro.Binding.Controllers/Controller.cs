using System.Threading.Tasks;
using NetMicro.Controllers;
using NetMicro.Routing;

namespace NetMicro.Binding.Controllers
{
    public class Controller<TRequestController, TContent>
        where TRequestController : IRequestController<TContent>
    {
        private readonly IRequestControllerExecutor<BoundRequestController<TRequestController, TContent>>
            _requestControllerExecutor;

        public Controller(
            IRequestControllerExecutor<BoundRequestController<TRequestController, TContent>> requestControllerExecutor)
        {
            _requestControllerExecutor = requestControllerExecutor;
        }

        public async Task Execute(Context context)
        {
            await _requestControllerExecutor.Execute(context);
        }
    }
}