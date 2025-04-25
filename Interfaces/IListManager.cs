namespace UtilitiesLib.Interfaces
{
    /// <summary>
    /// Generic interface using the List Manager class
    /// </summary>
    /// <typeparam name="T">Generic enumerable object type</typeparam>
    public interface IListManager<T>
    {
        /// <summary>
        /// Adds object T to list
        /// </summary>
        public abstract void AddObject(T obj);
        /// <summary>
        /// Adds multiple objects to list
        /// </summary>
        public void AddRange(IEnumerable<T> objs);
        /// <summary>
        /// Removes object at index
        /// </summary>
        public abstract void RemoveAt(int index);
        /// <summary>
        /// Replaces object T at index
        /// </summary>
        public abstract void ReplaceAt(T obj, int index);
        /// <summary>
        /// Gets object at index
        /// </summary>
        public abstract T GetObject(int index);
        /// <summary>
        /// Gets list of all objects
        /// </summary>
        public abstract List<T> GetObjects();
        /// <summary>
        /// Gets index of specific object
        /// </summary>
        public abstract int GetIndexOf(T obj);
        /// <summary>
        /// Gets list length
        /// </summary>
        public abstract int Count();
        /// <summary>
        /// Gets list of string objects from list
        /// </summary>
        public abstract List<string> GetStringList();
        /// <summary>
        /// Gets array of strings from list
        /// </summary>
        public abstract string[] GetStringArray();
        /// <summary>
        /// Removes all objects from list
        /// </summary>
        public abstract void Clear();

    }
}
