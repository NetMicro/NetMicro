using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using NetMicro.Routing;

namespace NetMicro.Controllers.Autofac
{
    public class RequestControllerExecutor<TRequestController> : IRequestControllerExecutor<TRequestController>
        where TRequestController : IRequestController
    {
        private readonly ILifetimeScope _scope;

        public RequestControllerExecutor(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task Execute(Context context)
        {
            using var requestScope = _scope.BeginLifetimeScope(builder => builder.RegisterContext(context));
            var requestController = requestScope.Resolve<TRequestController>();
            await requestController.Execute();
        }
    }
}