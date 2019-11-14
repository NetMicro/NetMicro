using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NetMicro.Http;

namespace NetMicro.Routing.SpecialRoutes
{
    internal class NotFound : IRoute
    {
        private static RouteFuncAsync HandlerFunc => async ctx => await Task.Run(
            () => ctx.Response.StatusCode = HttpStatusCode.NotFound
        );

        public IRequestHandler GetRequestHandler(Request request, IResponse response)
        {
            return new RequestHandler(HandlerFunc, GetContext(response));
        }

        private static Context GetContext(IResponse response)
        {
            return new Context(
                new SelectedRoute("", "", new Dictionary<string, string>()),
                null,
                response);
        }

        public void Use(RouteFuncAsyncMiddleware middlewareFunc)
        {
            throw new System.NotImplementedException();
        }
    }
}