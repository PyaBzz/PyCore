using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using PyaFramework.Core;

namespace PyaFramework.CoreMvc
{
    public static class Extensions
    {
        public static string ShortNameOf<T>(this IHtmlHelper helper) where T : Controller
        {
            return typeof(T).Name.TrimEnd("Controller");
        }

        public static IHtmlContent LinkToAction<T>(this IHtmlHelper thisHelper, string actionName, string linkText) where T : Controller
        {
            return thisHelper.ActionLink(linkText, actionName, thisHelper.ShortNameOf<T>());
        }

        public static IHtmlContent LinkToAction<T>(this IHtmlHelper thisHelper, string actionName, string linkText, Guid routeId) where T : Controller
        {
            return thisHelper.ActionLink(
                linkText: linkText,
                actionName: actionName,
                controllerName: thisHelper.ShortNameOf<T>(),
                routeValues: new { id = routeId }
                );
        }
    }
}
