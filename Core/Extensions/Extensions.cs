using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using PyaFramework.Core;

namespace PyaFramework.Core
{
    public static partial class Extensions
    {
        public static string TrimEnd(this string @this, string tail)
            => @this.EndsWith(tail) ? @this.Remove(@this.Length - tail.Length) : @this;

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

        public static IEnumerable<PropertyInfo> GetPublicInstancePropertyInfos(this Type T)
            => T.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        public static IEnumerable<PropertyInfo> GetPublicDeclaredInstancePropertyInfos(this Type T)
            => T.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

        //Task: See if there's any built-in object binding facility in NetCore.
        public static string GetStringOfProperties<T>(this T obj)
            => typeof(T).GetPublicInstancePropertyInfos().Select(propInfo => propInfo.GetValue(obj)).ToString(" ");

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
    }
}
