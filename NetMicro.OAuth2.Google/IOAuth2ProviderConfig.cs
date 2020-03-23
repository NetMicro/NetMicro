namespace NetMicro.OAuth2.Google
{
    public interface IGoogleOAuth2ProviderConfig
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string RedirectUri { get; }
    }
}