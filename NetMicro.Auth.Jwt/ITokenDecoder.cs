namespace NetMicro.Auth.Jwt
{
    public interface ITokenDecoder<out TToken>
    {
        TToken DecodeToken(string token);
    }
}