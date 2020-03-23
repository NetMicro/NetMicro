using System;
using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Google
{
    public class UserInfo
    {
        public UserInfo(string responseString)
        {
            var jObject = JObject.Parse(responseString);

            Sub = (string) jObject["sub"];
            Name = (string) jObject["name"];
            GivenName = (string) jObject["given_name"];
            FamilyName = (string) jObject["family_name"];
            Picture = (string) jObject["picture"];
            Email = (string) jObject["email"];
            EmailVerified = bool.Parse((string) jObject["email_verified"]);
            Locale = (string) jObject["locale"];
        }

        public string Sub { get; }
        public string Name { get; }
        public string GivenName { get; }
        public string FamilyName { get; }
        public string Picture { get; }
        public string Email { get; }
        public bool EmailVerified { get; }
        public string Locale { get; }
    }
}