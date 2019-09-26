using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NetMicro.Queues.Simple
{
    public class ObjectPool<T>
    {
        private readonly Stack<T> _pooledObjects;
        private readonly HashSet<T> _lockedObjects;
        private readonly object _poolModificationMutex = new object();
        private readonly object _poolGettingMutex = new object();

        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        public ObjectPool(IEnumerable<T> pooledObjects)
        {
            _lockedObjects = new HashSet<T>();
            this._pooledObjects = new Stack<T>(pooledObjects);
        }

        public T Get()
        {
            lock (_poolGettingMutex)
            {
                if (!HasFreeObject())
                    WaitForFreeObject();

                lock (_poolModificationMutex)
                {
                    _autoResetEvent.Reset();

                    var element = _pooledObjects.Pop();
                    _lockedObjects.Add(element);

                    return element;
                }
            }
        }

        private void WaitForFreeObject()
        {
            _autoResetEvent.WaitOne();
        }

        public void FreeElement(T element)
        {
            lock (_poolModificationMutex)
            {
                _lockedObjects.Remove(element);
                _pooledObjects.Push(element);

                NoticeFreedObject();
            }
        }

        private void NoticeFreedObject()
        {
            _autoResetEvent.Set();
        }

        public bool HasFreeObject()
        {
            return _pooledObjects.Any();
        }

        public void Add(T element)
        {
            lock (_poolModificationMutex)
            {
                _pooledObjects.Push(element);

                NoticeFreedObject();
            }            
        }
    }
}