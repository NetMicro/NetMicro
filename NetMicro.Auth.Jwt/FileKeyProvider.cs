using System.IO;

namespace NetMicro.Auth.Jwt
{
    public class FileKeyProvider : IKeyProvider
    {
        public FileKeyProvider(string file)
        {
            using (var sr = new StreamReader(file))
            {
                Key = sr.ReadToEnd();
            }
        }

        public string Key { get; }
    }
}