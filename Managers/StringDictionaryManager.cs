using UtilitiesLib.Interfaces;

namespace UtilitiesLib.Managers
{
    public class StringDictionaryManager<TValue> : IDictionaryManager<string, TValue>
    {
        private Dictionary<string, TValue> dictionary = [];
        public void AddValue(string key, TValue value)
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

        public TValue GetValue(string key)
        {
            TValue? returnValue;
            dictionary.TryGetValue(key, out returnValue);
            return returnValue;
        }

        public List<TValue> GetValues()
        {
            List<TValue> list = [];
            foreach(KeyValuePair<string, TValue> pair in dictionary) list.Add(pair.Value);
            return list;

        }

        public void RemoveAt(string key)
        {
            dictionary.Remove(key);
        }

        public void ReplaceAt(TValue value, string key)
        {
            dictionary.Remove(key);
            dictionary.Add(key, value);
        }
    }
}
