namespace NetMicro.OAuth2.Facebook
{
    public interface IFacebookOAuth2ProviderConfig
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string RedirectUri { get; }
    }
}