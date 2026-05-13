
namespace NotificationApp.DALLibrary
{
    /// <summary>
    /// </summary>
    public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class
    {
        protected NotificationAppContext context;
        protected AbstractRepository()
        {
            context = new NotificationAppContext();
        }
        public T Create(T item)
        {
            context.Add(item);
            context.SaveChanges();
            return item;
        }

        /// <summary>Removes and returns entity by key.</summary>
        public T? Delete(K key)
        {
            T? item = Get(key);
            if (item == null)
            {
                throw new Exception("Item doesn't exist");
            }
            context.Remove(item);
            context.SaveChanges();
            return item;
        }

        /// <summary>Looks up entity by key.</summary>
        public abstract T? Get(K key);

        /// <summary>Returns all stored entities as a list.</summary>
        public List<T>? GetAll()
        {
            return [.. context.Set<T>()];
        }

        /// <summary>Replaces entity at key with updated version.</summary>
        public T? Update(K key, T item)
        {
            var currItem=Get(key);
            if(currItem==null) throw new Exception("Item doesn't exist");
            context.Update(item);
            return item;
        }

    }
}