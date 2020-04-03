using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Facebook
{
    public class FacebookOAuth2Provider<TProfile> : IOAuth2Provider<TProfile>
    {
        private const string FacebookProviderName = "facebook";
        
        private const string ClientIdField = "client_id";
        private const string ClientSecretField = "client_secret";
        private const string CodeField = "code";
        private const string RedirectUriField = "redirect_uri";

        private const string FieldsField = "fields";
        private const string FieldsFieldValue = "first_name,last_name,middle_name,name,name_format,picture,short_name,email";

        private readonly IProfileParser<TProfile> _profileParser;
        private readonly IFacebookOAuth2ProviderConfig _config;
        private readonly HttpClient _client;


        public FacebookOAuth2Provider(
            IProfileParser<TProfile> profileParser,
            IFacebookOAuth2ProviderConfig config,
            HttpClient client)
        {
            _profileParser = profileParser;
            _config = config;
            _client = client;
        }

        public string Name => FacebookProviderName;


        public async Task<IAuthResponse> GetAccessToken(string code)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query[ClientIdField] = _config.ClientId;
            query[RedirectUriField] = _config.RedirectUri;
            query[ClientSecretField] = _config.ClientSecret;
            query[CodeField] = code;
            var queryString = query.ToString();

            var response = await _client.GetAsync($"https://graph.facebook.com/v6.0/oauth/access_token?{queryString}");
            var responseString = await response.Content.ReadAsStringAsync();
            return new FacebookAuthResponse(responseString);
        }

        public async Task<TProfile> GetProfile(string token)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query[FieldsField] = FieldsFieldValue;
            var queryString = query.ToString();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/me?{queryString}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            return _profileParser.Parse(new UserInfo(responseString));
        }
    }
}