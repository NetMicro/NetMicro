using NetMicro.Bootstrap.Config;
using NetMicro.Routing;
using NetMicro.Routing.Modules;

namespace NetMicro.Bootstrap
{
    public class ErrorHandlingModule : IModule
    {
        private readonly IDevelopmentConfiguration _developmentConfiguration;

        public ErrorHandlingModule(IDevelopmentConfiguration developmentConfiguration)
        {
            _developmentConfiguration = developmentConfiguration;
        }

        public void Configure(IRouter router)
        {
            router.UseRestErrorHandling(_developmentConfiguration);
        }
    }
}