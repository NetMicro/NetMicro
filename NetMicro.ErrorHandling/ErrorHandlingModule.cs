using Microsoft.Extensions.Logging;
using NetMicro.Routing;
using NetMicro.Routing.Modules;

namespace NetMicro.ErrorHandling
{
    public class ErrorHandlingModule : IModule
    {
        private readonly IErrorHandlingConfiguration _errorHandlingConfiguration;
        private readonly ExceptionStatusCodeMapper _exceptionStatusCodeMapper;
        private readonly ILoggerFactory _loggerFactory;

        public ErrorHandlingModule(
            IErrorHandlingConfiguration errorHandlingConfiguration,
            ExceptionStatusCodeMapper exceptionStatusCodeMapper,
            ILoggerFactory loggerFactory
        )
        {
            _errorHandlingConfiguration = errorHandlingConfiguration;
            _exceptionStatusCodeMapper = exceptionStatusCodeMapper;
            _loggerFactory = loggerFactory;
        }

        public void Configure(IRouter router)
        {
            router.UseRestErrorHandling(_errorHandlingConfiguration, _exceptionStatusCodeMapper, _loggerFactory.CreateLogger<ErrorHandlingModule>());
        }
    }
}