using System;
using System.Collections;
using System.Collections.Generic;

namespace NetMicro.Routing
{
    public class ContextExtensions : IEnumerable<Type>
    {
        private readonly IDictionary<Type, object> _extensions = new Dictionary<Type, object>();

        public void Register<TDataType>(TDataType data)
        {
            _extensions.Add(typeof(TDataType), data);
        }

        public TDataType Get<TDataType>()
        {
            return (TDataType)_extensions[typeof(TDataType)];
        }

        public object Get(Type type)
        {
            return _extensions[type];
        }
        
        public bool Has<TDataType>()
        {
            return _extensions.Keys.Contains(typeof(TDataType));
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return _extensions.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}