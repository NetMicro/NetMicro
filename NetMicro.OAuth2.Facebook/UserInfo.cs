using Newtonsoft.Json.Linq;

namespace NetMicro.OAuth2.Facebook
{
    public class UserInfo
    {
        public UserInfo(string responseString)
        {
            var jObject = JObject.Parse(responseString);

            Id = (string) jObject["id"];
            Name = (string) jObject["name"];
            FirstName = (string) jObject["first_name"];
            LastName = (string) jObject["last_name"];
            NameFormat = (string) jObject["name_format"];
            ShortName = (string) jObject["short_name"];
            Picture = new UserInfoPicture(jObject["picture"]);
            Email = (string) jObject["email"];
        }
        
        public string Id { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string NameFormat { get; }
        public string ShortName { get; }
        public UserInfoPicture Picture { get; }
        public string Email { get; }
    }

    public class UserInfoPicture
    {
        public UserInfoPicture(JToken picture)
        {
            Height = picture["data"]["height"].ToObject<int>();
            IsSilhouette = bool.Parse((string)picture["data"]["is_silhouette"]);
            Url = (string) picture["data"]["url"];
            Width = picture["data"]["width"].ToObject<int>();
        }

        public int Width { get; }

        public string Url { get; }

        public bool IsSilhouette { get; }

        public int Height { get; }
    }
}