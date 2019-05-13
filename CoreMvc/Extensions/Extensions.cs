using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using PyaFramework.Core;
using System.Dynamic;

namespace PyaFramework.CoreMvc
{
    public static class Extensions
    {
        public static string ShortNameOf<T>(this IHtmlHelper @this) where T : Controller
            => typeof(T).Name.TrimEnd("Controller");
    }
}
