using NetMicro.ErrorHandling;
using NetMicro.Routing;
using NetMicro.Routing.Modules;

namespace NetMicro.Bootstrap
{
    public class ErrorHandlingModule : IModule
    {
        private readonly IDevelopmentConfiguration _developmentConfiguration;
        private readonly ExceptionStatusCodeMapper _exceptionStatusCodeMapper;

        public ErrorHandlingModule(
            IDevelopmentConfiguration developmentConfiguration, 
            ExceptionStatusCodeMapper exceptionStatusCodeMapper
        )
        {
            _developmentConfiguration = developmentConfiguration;
            _exceptionStatusCodeMapper = exceptionStatusCodeMapper;
        }

        public void Configure(IRouter router)
        {
            router.UseRestErrorHandling(_developmentConfiguration, _exceptionStatusCodeMapper);
        }
    }
}