using System;
using System.Collections.Generic;
using System.Linq;

namespace PyaFramework.Core
{
    public static partial class Extensions
    {
        public static string ToString<T>(this IEnumerable<T> source, string separator)
            => string.Join(separator, source);

        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> source)
            => source ?? new List<T>();

        public static bool Lacks<T>(this IEnumerable<T> @this, T element)
            => @this.Contains(element) == false;

        public static IEnumerable<T> AppliedWithFilters<T>(this IEnumerable<T> source, IEnumerable<Func<T, bool>> filters)
        {
            foreach (var filter in filters)
                source = source.Where(i => filter(i));
            return source;
        }

        public static IEnumerable<T> AppliedWithFilters<T>(this IEnumerable<T> source, IEnumerable<Predicate<T>> filters)
        {
            foreach (var filter in filters)
                source = source.Where(i => filter(i));
            return source;
        }
    }
}
