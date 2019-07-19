using System.Diagnostics;

namespace Py.Services
{
    public static class NameOf
    {
        public static string ThisMethod
            => new StackTrace().GetFrame(1).GetMethod().Name;
    }
}
