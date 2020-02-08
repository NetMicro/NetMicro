using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetMicro.Http
{
    public class Query
    {
        private readonly QueryParam[] _params;

        internal Query()
        {
            _params = new QueryParam[0];
        }

        internal Query(QueryParam[] @params)
        {
            _params = @params;
        }

        public string GetValue(string name)
        {
            return _params.LastOrDefault(qp => qp.Name == name)?.Value;
        }

        public string[] GetValues(string name)
        {
            return _params.Where(qp => qp.Name == name).Select(qs => qs.Value).ToArray();
        }

        public Dictionary<string, string> GetDictionary(string name)
        {
            var dictRegex = new Regex($@"^{name}\[([^\]]+)\]$");
            return _params.Where(qp => dictRegex.IsMatch(qp.Name))
                .ToDictionary(
                    qp => dictRegex.Match(qp.Name).Groups[1].Value,
                    qp => qp.Value
                );
        }

        public List<QueryParam> ToList()
        {
            var ret = new List<QueryParam>(_params.Length);
            ret.AddRange(_params);

            return ret;
        }
    }
}