using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();
            var randomIndex = Random.Range(0, count);
            return enumerable.ElementAt(randomIndex);
        }
    }
}