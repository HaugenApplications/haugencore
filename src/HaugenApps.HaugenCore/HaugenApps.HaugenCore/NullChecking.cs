using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaugenApps.HaugenCore
{
    public static class NullChecking
    {
        /// <summary>
        /// Throws ArgumentNullExceptions for any null properties.
        /// </summary>
        /// <param name="obj">The object whose properties should be checked. Do not use this method in situations where the exception's callstack must not be polluted. Example: ThrowArgumentNullExceptions(new { UserId, Title })</param>
        public static void ThrowArgumentNullExceptions(object obj)
        {
            if (obj == null)
                return;

            ThrowArgumentNullExceptions(obj.GetType().GetProperties().ToDictionary(c => c.Name, c => c.GetValue(obj, null)));
        }

        /// <summary>
        /// Throws ArgumentNullExceptions for any null values. Do not use this method in situations where the exception's callstack must not be polluted.
        /// </summary>
        /// <param name="dict">The dictionary whose elements should be checked. The key will be used as the argument name.</param>
        public static void ThrowArgumentNullExceptions(IDictionary<string, object> dict)
        {
            foreach (var v in dict)
            {
                if (v.Value == null)
                {
                    throw new ArgumentNullException(v.Key);
                }
            }
        }
    }
}
