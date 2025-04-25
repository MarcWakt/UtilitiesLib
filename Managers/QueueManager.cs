using UtilitiesLib.Interfaces;

namespace UtilitiesLib.Managers
{
    public class QueueManager<T> : IQueueManager<T>
    {
        protected Queue<T> queue = [];
        public T Back()
        {
            return queue.Last();
        }

        public bool Empty()
        {
            return queue.Count > 0;
        }

        public T Front()
        {
            return queue.First();
        }

        public T Pop()
        {
            return queue.Dequeue();
        }

        public List<T> PopAll()
        {
            List<T> list = new List<T>();
            foreach(T item in queue) list.Add(queue.Dequeue());
            return list;
        }

        public void Push(T obj)
        {
            queue.Enqueue(obj);
        }

        public int Size()
        {
            return queue.Count;
        }
    }
}
