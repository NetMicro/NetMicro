namespace NetMicro.OAuth2.Google
{
    public interface IProfileParser<out TProfile>
    {
       TProfile Parse(UserInfo userInfo);
    }
}