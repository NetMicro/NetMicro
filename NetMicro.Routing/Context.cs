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
        }

        public SelectedRoute SelectedRoute { get; }
        public Request Request { get; }
        public IResponse Response { get; }
    }
}