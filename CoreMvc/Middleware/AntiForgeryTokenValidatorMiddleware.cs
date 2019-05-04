using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace PyaFramework.Middleware
{
    public class AntiForgeryTokenValidatorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IAntiforgery antiforgeryFacility;

        public AntiForgeryTokenValidatorMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            this.next = next;
            antiforgeryFacility = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method))
            {
                var valid = true;

                try
                {
                    await antiforgeryFacility.ValidateRequestAsync(context);
                }
                catch (Exception e)
                {
                    if (e is AntiforgeryValidationException)
                    {
                        valid = false;
                        // Redirect or directly write into the response
                        //context.Response.Redirect(context.Request.PathBase + "WorkItems/ListOfWorkItems?message=Not%20allowed");
                        await context.Response.WriteAsync("Not allowed!");
                    }
                }

                if (valid) await next(context);
            }
            else
            {
                await next(context);
            }
        }
    }
}