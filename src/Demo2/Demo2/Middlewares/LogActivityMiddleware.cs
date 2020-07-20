using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Demo2.Middlewares
{
    //Incomplete middleware, pending in exercise 1 of module 2
    public class LogActivityMiddleware
    {
        #region Properties

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        #endregion

        /// <summary>
        /// Constructor of middleware
        /// </summary>
        /// <param name="next"></param>
        public LogActivityMiddleware(RequestDelegate next, ILogger<LogActivityMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// method Invoke for register all activity middlewares of app
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;
            await _next(context);
            var responseCode = context.Response.StatusCode;
            _logger.LogInformation($"{path} – {responseCode}");
        }
    }

    public static class LogActivityMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogActivityMiddleware(this IApplicationBuilder builder)
           => builder.UseMiddleware<LogActivityMiddleware>();
    }
}
