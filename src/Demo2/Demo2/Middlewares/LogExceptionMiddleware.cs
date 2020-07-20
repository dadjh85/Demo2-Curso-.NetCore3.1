using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo2.Middlewares
{
    public class LogExceptionMiddleware
    {
        #region Properties

        private readonly RequestDelegate _next;

        #endregion

        /// <summary>
        /// Constructor of middleware
        /// </summary>
        /// <param name="next"></param>
        public LogExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// method Invoke for capture all exception middlewares of app
        /// </summary>
        /// <param name="httpContext">context of request</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }

    /// <summary>
    /// method extension used to add the middleware to the HTTP request pipeline
    /// </summary>
    public static class LogExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogExceptionMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<LogExceptionMiddleware>();
    }
}

