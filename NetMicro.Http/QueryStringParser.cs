using System.Linq;

namespace NetMicro.Http
{
    public class QueryStringParser
    {
        public static Query Parse(string query)
        {
            return string.IsNullOrEmpty(query.TrimStart('?')) 
                ? new Query() 
                : new Query(ReadQuery(query));
        }

        private static QueryParam[] ReadQuery(string query)
        {
            return query
                .TrimStart('?')
                .Split("&")
                .Select(ps => new QueryParam(ps))
                .ToArray();
        }
    }
}