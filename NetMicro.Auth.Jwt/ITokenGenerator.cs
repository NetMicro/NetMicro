namespace NetMicro.Auth.Jwt
{
    public interface ITokenGenerator<in TToken>
    {
        string CreateToken(TToken data);
    }
}