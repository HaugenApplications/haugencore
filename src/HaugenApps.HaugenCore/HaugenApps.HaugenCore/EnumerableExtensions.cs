using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaugenApps.HaugenCore
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns an array representing the elements in the enumerable, only looping through them if necessary. The method has no effect if the initial collection is already an array.
        /// </summary>
        public static T[] AsArray<T>(this IEnumerable<T> coll)
        {
            NullChecking.ThrowArgumentNullExceptions(new { coll });

            var array = coll as T[];
            if (array != null)
                return array;
            else
                return coll.ToArray();
        }

        /// <summary>
        /// Attempts to retrieve the first element in a collection. Use this method to know whether an element was returned, even if that element happens to be the default value for its type.
        /// </summary>
        /// <param name="Result">The resultant element.</param>
        /// <returns>Returns true if an element was retrieved, otherwise false.</returns>
        public static bool TryFirst<T>(this IEnumerable<T> coll, out T Result)
        {
            NullChecking.ThrowArgumentNullExceptions(new { coll });

            var enumerator = coll.GetEnumerator();
            if (enumerator.MoveNext())
            {
                Result = enumerator.Current;
                return true;
            }
            else
            {
                Result = default(T);
                return false;
            }
        }

        /// <summary>
        /// Attempts to retrieve the only element in a collection. Use this method to know whether an element was returned, even if that element happens to be the default value for its type.
        /// </summary>
        /// <param name="Result">The resultant element.</param>
        /// <returns>Returns true if exactly one element was found, otherwise false.</returns>
        public static bool TrySingle<T>(this IEnumerable<T> coll, out T Result)
        {
            NullChecking.ThrowArgumentNullExceptions(new { coll });

            var enumerator = coll.GetEnumerator();
            if (enumerator.MoveNext())
            {
                Result = enumerator.Current;

                return !enumerator.MoveNext();
            }
            else
            {
                Result = default(T);
                return false;
            }
        }
    }
}
