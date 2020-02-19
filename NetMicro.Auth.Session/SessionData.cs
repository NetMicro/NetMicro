using System.Collections;
using System.Collections.Generic;

namespace NetMicro.Auth.Session
{
    public class SessionData : IEnumerable<string>
    {
        private readonly IDictionary<string, object> _data = new Dictionary<string, object>();

        public void AddData<TDataType>(string key, TDataType data)
        {
            _data.Add(key, data);
        }

        public TDataType Get<TDataType>(string key)
        {
            return (TDataType)_data[key];
        }

        public bool Has(string key)
        {
            return _data.Keys.Contains(key);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _data.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}