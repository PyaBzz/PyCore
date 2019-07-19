namespace Py.Core
{
    public static partial class Extensions
    {
        public static string TrimEnd(this string @this, string tail)
            => @this.EndsWith(tail) ? @this.Remove(@this.Length - tail.Length) : @this;

        public static bool HasValue(this string @this)
            => @this != null && @this != string.Empty;
    }
}
