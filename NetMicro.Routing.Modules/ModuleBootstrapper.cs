using System.Collections.Generic;

namespace NetMicro.Routing.Modules
{
    public class ModuleBootstrapper : IBootstrapper
    {
        private readonly IList<IModule> _modules = new List<IModule>();

        public void Configure(IRouter router)
        {
            foreach (var module in _modules)
                module.Configure(router);
        }

        public ModuleBootstrapper RegisterModule(IModule module)
        {
            _modules.Add(module);

            return this;
        }
    }
}