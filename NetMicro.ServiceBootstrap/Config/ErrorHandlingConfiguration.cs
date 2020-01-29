using NetMicro.ErrorHandling;

namespace NetMicro.ServiceBootstrap.Config
{
    public class ErrorHandlingConfiguration : IErrorHandlingConfiguration
    {
        private readonly IDevelopmentConfiguration _developmentConfiguration;

        public ErrorHandlingConfiguration(IDevelopmentConfiguration developmentConfiguration)
        {
            _developmentConfiguration = developmentConfiguration;
        }

        public bool ShowCallStack => _developmentConfiguration.DisableSecurity;
    }
}