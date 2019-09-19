namespace NetMicro.Auth.Jwt
{
    public interface IKeyProvider
    {
        string Key { get; }
    }
}