using System.Collections.Generic;

namespace TechInterviewOne.Problem1
{
    public interface IMultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        IEnumerable<TValue> this[TKey key] { get; }

        TValue Add(TKey key, TValue value);       
        
        bool Remove(TKey key, TValue value);

        bool RemoveAll(TKey key);
        
        void Clear();

        bool ContainsKey(TKey key);

        bool ContainsValue(TKey key, TValue value);

        IEnumerable<TKey> Keys();

        IEnumerable<TValue> Values();

        IEnumerable<KeyValuePair<TKey, TValue>> Items();
    }
}