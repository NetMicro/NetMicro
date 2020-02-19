using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetMicro.LoadBalancing
{
    public class RoundRobin<T> : ILoadBalancer<T>
    {
        private readonly IList<T> _items = new List<T>();
        private readonly object _itemsMutex = new object();

        private int _lastUsed;

        public void Update(T[] newItems)
        {
            lock (_itemsMutex)
            {
                foreach (var item in _items.Where(item => !newItems.Contains(item)).ToList())
                    Remove(item);

                foreach (var item in newItems.Where(i => !_items.Contains(i)))
                    Add(item);
            }
        }

        public T Get()
        {
            lock (_itemsMutex)
            {
                if (_items.Count == 0)
                    return default(T);

                if (_lastUsed >= _items.Count)
                    _lastUsed = 0;

                return _items[_lastUsed++];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            lock (_itemsMutex)
            {
                _items.Add(item);
            }
        }

        public void Clear()
        {
            lock (_itemsMutex)
            {
                _items.Clear();
                _lastUsed = 0;
            }
        }

        public bool Contains(T item)
        {
            lock (_itemsMutex)
            {
                return _items.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (_itemsMutex)
            {
                _items.CopyTo(array, arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            lock (_itemsMutex)
            {
                var indexOfRemoved = _items.IndexOf(item);
                if (indexOfRemoved > -1 && _lastUsed > indexOfRemoved)
                    _lastUsed--;

                return _items.Remove(item);
            }
        }

        public int Count => _items.Count;
        public bool IsReadOnly => _items.IsReadOnly;
    }
}