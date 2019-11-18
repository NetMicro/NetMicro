using NetMicro.Http;

namespace NetMicro.Routing
{
    public class Context
    {
        public Context(SelectedRoute selectedRoute,
            Request request,
            IResponse response)
        {
            SelectedRoute = selectedRoute;
            Request = request;
            Response = response;
            Extensions = new ContextExtensions();
        }

        public SelectedRoute SelectedRoute { get; }
        public Request Request { get; }
        public IResponse Response { get; }
        public ContextExtensions Extensions { get; }
    };
}