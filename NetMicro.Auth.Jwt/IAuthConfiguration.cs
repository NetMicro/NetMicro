namespace NetMicro.Auth.Jwt
{
    public interface IAuthConfiguration
    {
        string PublicKey { get; }
        string PrivateKey { get; }
        string Secret { get; }
    }
}