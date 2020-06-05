using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Baz.Core
{
    public static partial class Extensions
    {
        //Task: See if there's any built-in object binding facility in NetCore.
        public static string GetStringOfProperties<T>(this T obj) where T : class
            => typeof(T).GetPublicInstancePropertyInfos()
            .Select(propInfo => propInfo.GetValue(obj))
            .ToString(" ");

        //public static string[] GetNonRelationalColumnNames(this SqlDataReader @this)
        //{
        //    var columns = new List<string>();
        //    for (var i = 0; i < @this.FieldCount; i++)
        //    {
        //        if (@this.GetDataTypeName(i) != "uniqueidentifier")
        //            columns.Add(@this.GetName(i));
        //    }
        //    return columns.ToArray();
        //}

        public static string GetDirectory(this Assembly @this)
        {
            var assemblyPath = @this.CodeBase;
            var uriBuilder = new UriBuilder(assemblyPath);
            var directory = Path.GetDirectoryName(uriBuilder.Path);
            return directory;
        }
    }
}
