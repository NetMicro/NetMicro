using System.Collections.Generic;
using System.Linq;

namespace NetMicro.OAuth2.Autofac
{
    public class OAuth2ProviderResolver<TProfile> : IOAuth2ProviderResolver<TProfile>
    {
        private readonly IDictionary<string, IOAuth2Provider<TProfile>> _providers;

        public OAuth2ProviderResolver(
            IEnumerable<IOAuth2Provider<TProfile>> providers
        )
        {
            _providers = providers.ToDictionary(p => p.Name, p => p);
        }

        public IOAuth2Provider<TProfile> GetProvider(string provider)
        {
            if (!_providers.ContainsKey(provider))
                throw new ProviderNotSupportedException(provider);

            return _providers[provider];
        }
    }
}