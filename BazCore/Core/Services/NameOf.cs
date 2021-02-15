using System.Diagnostics;

namespace Baz.Services
{
    public static class NameOf
    {
        public static string ThisMethod
            => new StackTrace().GetFrame(1).GetMethod().Name;
    }
}
