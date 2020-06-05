using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Baz.CoreMvc
{
    public static class AreaOf<T> where T : Controller
    {
        public static string Name
        {
            get
            {
                var controllerAreaAttribute = typeof(T).GetCustomAttribute(typeof(AreaAttribute));
                if (controllerAreaAttribute == null)
                    throw new ValidationException("The controller has no Area attribute!");
                else
                    return typeof(AreaAttribute).GetProperty("RouteValue").GetValue(controllerAreaAttribute) as string;
            }
        }
    }

    public static class Area
    {
        public static string Of(Type T)
        {
            if (T.IsSubclassOf(typeof(Controller)) == false)
                throw new ValidationException("The provided type isn't controller!");

            var controllerAreaAttribute = T.GetCustomAttribute(typeof(AreaAttribute));

            if (controllerAreaAttribute == null)
                throw new ValidationException("The controller has no Area attribute!");
            else
                return typeof(AreaAttribute).GetProperty("RouteValue").GetValue(controllerAreaAttribute) as string;
        }
    }
}
