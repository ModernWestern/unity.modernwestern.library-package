using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace ModernWestern
{
    public static class VectorExtensions
    {
        public static Vector3[] OrderAscending(this IEnumerable<Vector3> collection)
        {
            return collection.OrderBy(v => v.sqrMagnitude).ToArray();
        }

        public static Vector3[] OrderDescending(this IEnumerable<Vector3> collection)
        {
            return collection.OrderByDescending(v => v.sqrMagnitude).ToArray();
        }

        public static Vector2[] OrderAscending(this IEnumerable<Vector2> collection)
        {
            return collection.OrderBy(v => v.sqrMagnitude).ToArray();
        }

        public static Vector2[] OrderDescending(this IEnumerable<Vector2> collection)
        {
            return collection.OrderByDescending(v => v.sqrMagnitude).ToArray();
        }
    }
}