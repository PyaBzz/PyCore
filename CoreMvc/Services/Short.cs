using Microsoft.AspNetCore.Mvc;
using PyaFramework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PyaFramework.CoreMvc
{
    public static class Short<T> where T : Controller
    {
        public static string Name =>
            typeof(T).Name.TrimEnd("Controller");
    }

    public static class ShortName
    {
        public static string Of(Type T)
        {
            if (T.IsSubclassOf(typeof(Controller)) == false)
                throw new ValidationException("The provided type isn't controller!");
            return T.Name.TrimEnd("Controller");
        }
    }
}
