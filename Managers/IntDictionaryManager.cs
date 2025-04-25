using UtilitiesLib.Interfaces;

namespace UtilitiesLib.Managers
{
    public class IntDictionaryManager<TValue> : IDictionaryManager<int, TValue>
    {
        private Dictionary<int, TValue> dictionary = [];
        public void AddValue(int key, TValue value)
        {
            dictionary.Add(key, value);
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public int Count()
        {
            return dictionary.Count;
        }

        public TValue GetValue(int key)
        {
            try
            {
                TValue? returnValue;
                dictionary.TryGetValue(key, out returnValue);
                return returnValue;
            }
            catch { throw new Exception("Dictionary error"); }
        }

        public List<TValue> GetValues()
        {
            List<TValue> list = [];
            foreach(KeyValuePair<int, TValue> pair in dictionary) list.Add(pair.Value);
            return list;

        }

        public void RemoveAt(int key)
        {
            dictionary.Remove(key);
        }

        public void ReplaceAt(TValue value, int key)
        {
            dictionary.Remove(key);
            dictionary.Add(key, value);
        }
    }
}
