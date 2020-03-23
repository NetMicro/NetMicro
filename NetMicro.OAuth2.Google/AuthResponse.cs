using System;
using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Google
{
    public class GoogleAuthResponse : IAuthResponse
    {
        public GoogleAuthResponse(string responseString)
        {
            var jObject = JObject.Parse(responseString);

            AccessToken = (string) jObject["access_token"];
            Expire =  DateTime.Now.AddSeconds(jObject["expires_in"].ToObject<int>());
            RefreshToken = (string) jObject["refresh_token"];
            Scope = (string) jObject["scope"];
            TokenType = (string) jObject["token_type"];
        }
        
        public string AccessToken { get; }
        public DateTime Expire { get; }
        public string RefreshToken { get; }
        public string Scope { get; }
        public string TokenType { get; }
    }
}