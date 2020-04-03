using System;
using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Facebook
{
    public class FacebookAuthResponse : IAuthResponse
    {
        public FacebookAuthResponse(string responseString)
        {
            var jObject = JObject.Parse(responseString);

            AccessToken = (string) jObject["access_token"];
            Expire =  DateTime.Now.AddSeconds(jObject["expires_in"].ToObject<int>());
            TokenType = (string) jObject["token_type"];
        }
        
        public string AccessToken { get; }
        public DateTime Expire { get; }
        public string TokenType { get; }
    }
}