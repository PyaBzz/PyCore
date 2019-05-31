using Microsoft.AspNetCore.Mvc;
using PyaFramework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PyaFramework.CoreMvc
{
    public static class ShortName
    {
        public static string Of<T>() where T : Controller
            => typeof(T).Name.TrimEnd("Controller");
    }
}
