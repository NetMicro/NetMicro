namespace NetMicro.OAuth2
{
    public interface IOAuth2ProviderResolver<TProfile>
    {
        IOAuth2Provider<TProfile> GetProvider(string provider);
    }
}