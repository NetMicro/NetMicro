using NetMicro.Routing;
using NetMicro.Routing.Modules;

namespace NetMicro.ErrorHandling
{
    public class ErrorHandlingModule : IModule
    {
        private readonly IErrorHandlingConfiguration _errorHandlingConfiguration;
        private readonly ExceptionStatusCodeMapper _exceptionStatusCodeMapper;

        public ErrorHandlingModule(
            IErrorHandlingConfiguration errorHandlingConfiguration, 
            ExceptionStatusCodeMapper exceptionStatusCodeMapper
        )
        {
            _errorHandlingConfiguration = errorHandlingConfiguration;
            _exceptionStatusCodeMapper = exceptionStatusCodeMapper;
        }

        public void Configure(IRouter router)
        {
            router.UseRestErrorHandling(_errorHandlingConfiguration, _exceptionStatusCodeMapper);
        }
    }
}