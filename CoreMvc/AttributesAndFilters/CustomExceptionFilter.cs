using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Py.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //public CustomExceptionFilterAttribute()
        //{
        //    //Constructor stuff
        //}

        public override void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult { Content = "Exception handled in this custom handler" };
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
        }
    }
}
