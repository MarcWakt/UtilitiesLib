using UtilitiesLib.Interfaces;

namespace UtilitiesLib.Managers
{
    /// <summary>
    /// Class implementing the IListManager interface
    /// </summary>
    public class ListManager<T> : IListManager<T>
    {
        protected List<T> list = [];
        public virtual void AddObject(T obj)
        {
            if (obj == null) throw new Exception("Added object cannot be null");

            list.Add(obj);
        }

        public void AddRange(IEnumerable<T> objs)
        {
            foreach(T obj in objs) AddObject(obj);
        }

        public int Count()
        {
            return list.Count;
        }

        public int GetIndexOf(T obj)
        {
            if (obj == null) throw new Exception("Searched object cannot be null");

            return list.IndexOf(obj);
        }

        public List<T> GetObjects()
        {
            return list;
        }


        public List<string> GetStringList()
        {
            try
            {
                List<string> strings = new List<string>();
                foreach (T t in list) { strings.Add(t.ToString()); }
                return strings;
            }
            catch { throw new Exception("Dictionary error"); }
        }
        public string[] GetStringArray()
        {
            return GetStringList().ToArray();
        }

        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= list.Count) throw new Exception("Index must be within list size");

            list.RemoveAt(index);
        }

        public virtual void ReplaceAt(T obj, int index)
        {
            if (obj == null) throw new Exception("Added object cannot be null");
            if (index < 0 || index >= list.Count) throw new Exception("Index must be within list size");

            list.RemoveAt(index);
            list.Insert(index, obj);
        }

        public T GetObject(int index)
        {
            if (index < 0 || index >= list.Count) throw new Exception("Index must be within list size");

            return list[index];
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
