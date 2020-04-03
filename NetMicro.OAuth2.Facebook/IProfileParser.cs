namespace NetMicro.OAuth2.Facebook
{
    public interface IProfileParser<out TProfile>
    {
       TProfile Parse(UserInfo userInfo);
    }
}