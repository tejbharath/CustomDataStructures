using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechInterviewOne.Problem1;

namespace TechInterviewOne.Solution
{
    public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>
    {
        private Dictionary<K, List<V>> dict;

        public MultiValueDictionary()
        {
            dict = new Dictionary<K, List<V>>();
        }
        public IEnumerable<V> this[K key]
        {
            get
            {
                dict.TryGetValue(key, out List<V> values);
                return values;
            }
        }

        public V Add(K key, V value)
        {
            if (dict.TryGetValue(key, out List<V> existingValues))
            {
                if (existingValues.Contains(value))
                {
                    throw new InvalidOperationException();
                }
                existingValues.Add(value);
            }
            else
            {
                var values = new List<V>() { value };
                dict.Add(key, values);
            }
            return value;
        }

        public void Clear()
        {
            dict.Clear();
        }

        public bool ContainsKey(K key)
        {
            if (dict.ContainsKey(key))
            {
                return true;
            }

            return false;
        }

        public bool ContainsValue(K key, V value)
        {
            if (dict.TryGetValue(key, out List<V> outValues))
            {
                if (outValues.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<K, V>> Items()
        {
            var kvl = new List<KeyValuePair<K, V>>();

            foreach (var keyValue in dict)
            {
                var key = keyValue.Key;
                var values = keyValue.Value;

                foreach (var value in values)
                {
                    kvl.Add(new KeyValuePair<K, V>(key, value));
                }
            }
            return kvl;
        }

        public IEnumerable<K> Keys()
        {
            return dict.Keys;
        }

        public bool Remove(K key, V value)
        {
            if (dict.TryGetValue(key, out List<V> outValues))
            {
                if (outValues.Contains(value))
                {
                    outValues.Remove(value);
                }
            }

            if (outValues?.Count == 0)
            {
                return dict.Remove(key);
            }
            return false;
        }

        public bool RemoveAll(K key)
        {
            if (dict.TryGetValue(key, out List<V> outValues))
            {
                outValues.RemoveRange(0, outValues.Count);
                return dict.Remove(key);
            }

            return false;
        }

        public IEnumerable<V> Values()
        {
            var values = new List<V>();
            if (values.Count > 0)
            {
                foreach (var list in dict.Values)
                {
                    values.AddRange(list);
                }
            }
            return values;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
