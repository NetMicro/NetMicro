using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Google
{
    public class GoogleOAuth2Provider<TProfile> : IOAuth2Provider<TProfile>
    {
        private const string GoogleProviderName = "google";
        
        private const string ClientIdFiled = "client_id";
        private const string ClientSecretField = "client_secret";
        private const string CodeField = "code";
        private const string GrantTypeField = "grant_type";
        private const string RedirectUriField = "redirect_uri";

        private const string GrantType = "authorization_code";
        private const string TokenEndpoint = "token_endpoint";
        private const string UserInfoEndpoint = "userinfo_endpoint";

        private readonly IProfileParser<TProfile> _profileParser;
        private readonly IGoogleOAuth2ProviderConfig _config;
        private readonly HttpClient _client;

        private JObject _discoveryObject;

        public GoogleOAuth2Provider(
            IProfileParser<TProfile> profileParser,
            IGoogleOAuth2ProviderConfig config,
            HttpClient client)
        {
            _profileParser = profileParser;
            _config = config;
            _client = client;
        }

        public string Name => GoogleProviderName;


        public async Task<IAuthResponse> GetAccessToken(string code)
        {
            var values = new Dictionary<string, string>
            {
                { ClientIdFiled, _config.ClientId },
                { ClientSecretField, _config.ClientSecret },
                { CodeField, code },
                { GrantTypeField, GrantType },
                { RedirectUriField, _config.RedirectUri }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await _client.PostAsync(await Discover(TokenEndpoint), content);
            var responseString = await response.Content.ReadAsStringAsync();
            return new GoogleAuthResponse(responseString);
        }

        public async Task<TProfile> GetProfile(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, await Discover(UserInfoEndpoint));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            return _profileParser.Parse(new UserInfo(responseString));
        }

        private async Task<string> Discover(string name)
        {
            if (_discoveryObject == null)
            {
                var discoveryResponse =
                    await _client.GetAsync("https://accounts.google.com/.well-known/openid-configuration");
                var discoveryResponseString = await discoveryResponse.Content.ReadAsStringAsync();
                _discoveryObject = JObject.Parse(discoveryResponseString);
            }

            return (string)_discoveryObject[name];
        }
    }
}