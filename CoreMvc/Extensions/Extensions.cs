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

        public static IHtmlContent LinkToAction<ControllerType>(this IHtmlHelper @this, string methodName, string linkText = null, Guid id = default(Guid)) where ControllerType : Controller
        {
            var caption = linkText ?? methodName;
            var controllerAreaAttribute = typeof(ControllerType).GetCustomAttribute(typeof(AreaAttribute));

            dynamic routeValues = new ExpandoObject();

            if (controllerAreaAttribute != null)
            {
                var areaName = typeof(AreaAttribute).GetProperty("RouteValue").GetValue(controllerAreaAttribute);
                routeValues.area = areaName;
            }

            if (id != Guid.Empty)
                routeValues.id = id;

            return @this.ActionLink(
                linkText: caption,
                actionName: methodName,
                controllerName: @this.ShortNameOf<ControllerType>(),
                routeValues: routeValues as object
                );
        }
    }
}
