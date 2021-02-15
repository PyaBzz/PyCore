using System;
using System.Collections.Generic;
using System.Linq;

namespace Baz.Core
{
    public static partial class Extensions
    {
        public static string ToString<T>(this IEnumerable<T> source, string separator)
            => string.Join(separator, source);

        public static string ToStringReversed<T>(this IEnumerable<T> source, string separator)
            => string.Join(separator, source.Reverse());

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

        public static void Shuffle<T>(this T[] @this)
        {
            var rand = new Random();
            for (var i = 0; i < @this.Count(); i++)
            {
                var k = rand.Next(i + 1);
                var temp = @this[k];
                @this[k] = @this[i];
                @this[i] = temp;
            }
        }
    }
}
