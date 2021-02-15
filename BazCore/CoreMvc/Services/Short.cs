using Microsoft.AspNetCore.Mvc;
using Baz.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Baz.CoreMvc
{
    public static class Short<T> where T : Controller
    {
        public static string Name =>
            typeof(T).Name.TrimEnd("Controller");
    }

    public static class Short
    {
        public static string NameOf(Type T)
        {
            if (T.IsSubclassOf(typeof(Controller)) == false)
                throw new ValidationException("The provided type isn't controller!");
            return T.Name.TrimEnd("Controller");
        }
    }
}
