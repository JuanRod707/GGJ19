using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers
{
    public static class ExtensionMethods
    {
        public static T PickOne<T>(this IEnumerable<T> source) => source.ToArray()[Random.Range(0, source.Count())];

        public static bool HasComponent<T>(this Component source) => source.GetComponent<T>() != null;
    }
}