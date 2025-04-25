namespace UtilitiesLib.Interfaces
{
    /// <summary>
    /// Generic interface using the Dictionary Manager class
    /// </summary>
    /// <typeparam name="TKey">Generic key type to access dictionary value</typeparam>
    /// <typeparam name="TValue">Generic enumerable object type</typeparam>
    public interface IDictionaryManager <TKey, TValue>
    {
        /// <summary>
        /// Adds value to dictionary coupled with key
        /// </summary>
        public abstract void AddValue(TKey key, TValue value);
        /// <summary>
        /// Removes value coupled with key
        /// </summary>
        public abstract void RemoveAt(TKey key);
        /// <summary>
        /// Replaces value coupled with key
        /// </summary>
        /// <param name="obj">New TValue to replace at Tkey</param>
        /// <param name="index">TKey associated with value to replace</param>
        public abstract void ReplaceAt(TValue value, TKey key);
        /// <summary>
        /// Gets value associated with key
        /// </summary>
        public abstract TValue GetValue(TKey key);
        /// <summary>
        /// Gets list of all values
        /// </summary>
        public abstract List<TValue> GetValues();
        /// <summary>
        /// Gets dictionary length
        /// </summary>
        public abstract int Count();
        /// <summary>
        /// Removes all objects from list
        /// </summary>
        public abstract void Clear();
    }
}
