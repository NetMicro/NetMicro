using System.Collections.Generic;
using Autofac;
using NetMicro.Routing.Modules;

namespace NetMicro.Routing.Autofac
{
    public class AutofacBootstrapper : IBootstrapper
    {
        private readonly ModuleBootstrapper _moduleBootstrapper = new ModuleBootstrapper();

        public AutofacBootstrapper(IComponentContext container)
        {
            foreach (var module in container.Resolve<IEnumerable<IModule>>())
                _moduleBootstrapper.RegisterModule(module);
        }

        public void Configure(IRouter router)
        {
            _moduleBootstrapper.Configure(router);
        }
    }
}