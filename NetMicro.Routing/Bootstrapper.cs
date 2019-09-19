using System;

namespace NetMicro.Routing
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly Action<IRouter> _configure;

        public Bootstrapper(Action<IRouter> configure)
        {
            _configure = configure;
        }

        public void Configure(IRouter router)
        {
            _configure(router);
        }
    }
}