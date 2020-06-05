using System;
using System.Collections.Generic;
using System.Reflection;

namespace Baz.Core
{
    public static partial class Extensions
    {
        public static IEnumerable<PropertyInfo> GetPublicInstancePropertyInfos(this Type T)
            => T.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        public static IEnumerable<PropertyInfo> GetPublicDeclaredInstancePropertyInfos(this Type T)
            => T.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
    }
}
