
namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Base repository with in-memory Dictionary storage.
    /// Subclasses must implement Create (for ID generation).
    /// </summary>
    public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class
    {
        // In-memory store; initialized by subclass constructors
        public Dictionary<K, T> _items;

        /// <summary>Abstract — subclass handles ID generation.</summary>
        public abstract T Create(T item);

        /// <summary>Removes and returns entity by key.</summary>
        public T? Delete(K key)
        {
            var item = _items[key];
            if (item == null) return null;
            _items.Remove(key);
            return item;
        }

        /// <summary>Looks up entity by key.</summary>
        public T? Get(K key)
        {
            var item = _items[key];
            if (item == null) return null;
            return item;

        }

        /// <summary>Returns all stored entities as a list.</summary>
        public List<T>? GetAll()
        {
            if (_items.Count == 0) return null;
            return _items.Values.ToList();
        }

        /// <summary>Replaces entity at key with updated version.</summary>
        public T? Update(K key, T item)
        {
            if (_items[key] == null) return null;
            _items[key] = item;
            return _items[key];
        }

    }
}