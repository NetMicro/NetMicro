using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMicro.Http.Rest
{
    public class Query
    {
        private const string FilterQueryName = "filter";
        private const string SkipQueryName = "skip";
        private const string LimitQueryName = "limit";
        private const string SortQueryName = "sort";

        private readonly Http.Query _query;

        public Query(Http.Query query)
        {
            _query = query;
        }

        public Dictionary<string, string> Filter => _query.GetDictionary(FilterQueryName);
        public int? Skip => GetSkip();
        public int? GetLimit(int maxLimit)
        {
            var queryLimit = GetNumber(LimitQueryName);
            if (queryLimit == null)
                return null;
            
            return Math.Min(queryLimit.Value, maxLimit);
        }

        public List<OrderInfo> Order => GetOrdering();

        private List<OrderInfo> GetOrdering()
        {
            return _query
                .GetDictionary(SortQueryName)
                .Select(kvp => new OrderInfo(kvp.Key, ParseOrder(kvp.Value)))
                .ToList();
        }

        private Order ParseOrder(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Rest.Order.Asc;

            if (value.ToLower() == "asc")
                return Rest.Order.Asc;
            
            if (value.ToLower() == "desc")
                return Rest.Order.Desc;
            
            throw new IncorrectOrderingValue(value);
        }

        private int? GetSkip()
        {
            return GetNumber(SkipQueryName);
        }

        private int? GetNumber(string paramName)
        {
            var value = _query.GetValue(paramName);
            if (value == null)
                return null;

            if (int.TryParse(value, out var n))
                return n;

            throw new ParamIsNotNumberException(value);
        }
    }
}