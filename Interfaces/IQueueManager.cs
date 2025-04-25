namespace UtilitiesLib.Interfaces
{
    /// <summary>
    /// Generic interface using the Queue Manager class
    /// </summary>
    /// <typeparam name="T">Generic enumerable object type</typeparam>
    public interface IQueueManager <T>
    {
        /// <summary>
        /// Adds object T to queue
        /// </summary>
        public abstract void Push(T obj);
        /// <summary>
        /// Gets first object and removes it from queue
        /// </summary>
        public abstract T Pop();
        /// <summary>
        /// Gets list of all objects and deletes them from queue
        /// </summary>
        public abstract List<T> PopAll();
        /// <summary>
        /// Gets size of queue
        /// </summary>
        public abstract int Size();
        /// <summary>
        /// Gets whether the queue is empty or not
        /// </summary>
        public abstract bool Empty();
        /// <summary>
        /// Gets last object from queue
        /// </summary>
        public abstract T Back();
        /// <summary>
        /// Gets first object from queue
        /// </summary>
        public abstract T Front();
    }
}
