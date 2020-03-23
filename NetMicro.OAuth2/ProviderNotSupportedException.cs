using System;

namespace NetMicro.OAuth2
{
    public class ProviderNotSupportedException : Exception
    {
        public ProviderNotSupportedException(string provider)
            :base($"Provider '{provider}' is not supported!")
        {
        }
    }
}