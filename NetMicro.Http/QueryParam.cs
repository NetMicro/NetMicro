using System.Web;

namespace NetMicro.Http
{
    public class QueryParam
    {
        public string Name { get; }
        public string Value { get; }

        public QueryParam(string paramString)
        {
            var paramParts = paramString.Split("=");
            if (paramParts.Length != 2)
                throw new InvalidQueryParam(paramString);

            Name = Decode(paramParts[0]);
            Value = Decode(paramParts[1]);
        }

        private static string Decode(string value)
        {
            return HttpUtility.UrlDecode(value);
        }
    }
}