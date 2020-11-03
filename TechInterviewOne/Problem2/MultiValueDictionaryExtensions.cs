using System;
using System.Linq;
using TechInterviewOne.Problem1;
using TechInterviewOne.Solution;

namespace TechInterviewOne.Problem2
{
    public static class MultiValueDictionaryExtensions
    {
        /// <summary>
        /// Time Complexity - O(n)
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IMultiValueDictionary<K, V> Union<K, V>(this IMultiValueDictionary<K, V> first, IMultiValueDictionary<K, V> second)
        {
            // INSTRUCTIONS :
            // * Return all items from "first" and "second" in a new Multivalue Dictionary

            /// Time Complexity - O(n)

            if (first.Items().Any() && second.Items().Any())
            {
                return new MultiValueDictionary<K, V>();
            }
            if (first.Items().Any() && second.Items().Any())
            {
                foreach (var value in second)
                {
                    first.Add(value.Key, value.Value);
                    return first;
                }
            }
            else if (first.Items().Any() && !second.Items().Any())
            {
                return first;
            }
            else
            {
                return second;
            }

            return new MultiValueDictionary<K, V>();
        }

        /// <summary>
        /// Time Complexity - O(n)  
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IMultiValueDictionary<K, V> Intersection<K, V>(this IMultiValueDictionary<K, V> first, IMultiValueDictionary<K, V> second)
        {
            // INSTRUCTIONS :
            // * Return only the items that exist in BOTH "first" and "second" in a new Multivalue Dictionary
            
            var mvd = new MultiValueDictionary<K,V>();
            foreach (var item in first.Items())
            {
                if (second.Items().Contains(item))
                {
                    mvd.Add(item.Key, item.Value);
                }
            }
            return mvd;
        }

        /// <summary>
        /// Time Complexity - O(n)
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IMultiValueDictionary<K, V> Except<K, V>(this IMultiValueDictionary<K, V> first, IMultiValueDictionary<K, V> second)
        {
            // INSTRUCTIONS :
            // Return the items that exist in "first" but NOT in "second"

            var mvd = new MultiValueDictionary<K, V>();
            foreach (var item in first.Items())
            {
                if (!second.Items().Contains(item))
                {
                    mvd.Add(item.Key, item.Value);
                }
            }
            return mvd;
        }

        /// <summary>
        /// Time Complexity - O(n) (foreach loops)
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IMultiValueDictionary<K, V> Distinct<K, V>(this IMultiValueDictionary<K, V> first, IMultiValueDictionary<K, V> second)
        {
            // INSTRUCTIONS :
            // Return only the items that exist in "first" OR "second", but not both

            var mvd = new MultiValueDictionary<K, V>();
            foreach (var item in first.Items())
            {
                if (second.Items().Contains(item))
                {
                    mvd.Add(item.Key, item.Value);
                }
            }

            foreach (var item in second.Items())
            {
                if (first.Items().Contains(item))
                {
                    mvd.Add(item.Key, item.Value);
                }
            }

            return mvd;
        }
    }
}
