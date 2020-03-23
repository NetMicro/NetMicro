using System.Threading.Tasks;

namespace NetMicro.OAuth2
{
    public interface IOAuth2Provider<TProfile>
    {
        public string Name { get; }
        public Task<IAuthResponse> GetAccessToken(string code);
        
        public Task<TProfile> GetProfile(string token);
    }
}