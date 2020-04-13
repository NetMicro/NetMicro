namespace NetMicro.Auth.Jwt
{
    public interface IAuthConfiguration
    {
        bool DisableAuth { get; }
        string AccessTokenPublicKey { get; }
        string AccessTokenPrivateKey { get; }
        string AccessTokenSecret { get; }
        string RefreshTokenPublicKey { get; }
        string RefreshTokenPrivateKey { get; }
        string RefreshTokenSecret { get; }
    }
}