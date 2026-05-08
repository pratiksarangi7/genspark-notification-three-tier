namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// Generic CRUD repository contract.
    /// K = key type, T = entity type.
    /// </summary>
    public interface IRepository<K, T> where T : class
    {
        /// <summary>Adds a new entity to the store.</summary>
        public T Create(T item);

        /// <summary>Retrieves entity by key; null if not found.</summary>
        public T? Get(K key);

        /// <summary>Returns all entities; null if empty.</summary>
        public List<T>? GetAll();

        /// <summary>Replaces entity at key; null if key missing.</summary>
        public T? Update(K key, T item);

        /// <summary>Removes entity by key; null if key missing.</summary>
        public T? Delete(K key);
    }

}