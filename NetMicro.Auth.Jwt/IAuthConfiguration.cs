namespace NetMicro.Auth.Jwt
{
    public interface IAuthConfiguration
    {
        string AccessTokenPublicKey { get; }
        string AccessTokenPrivateKey { get; }
        string AccessTokenSecret { get; }
        string RefreshTokenPublicKey { get; }
        string RefreshTokenPrivateKey { get; }
        string RefreshTokenSecret { get; }
    }
}