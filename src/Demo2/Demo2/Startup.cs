using Demo2.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Demo2
{
    public class Startup
    {
        /// <summary>
        /// Constructor of startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Object of load the personal configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// dependency injection container of .NET Core
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging(logging => logging.AddConsole());
        }

        /// <summary>
        /// Exclusive pipeline of the environment Development
        /// </summary>
        /// <param name="services"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //personal Middleware for capture the exceptions of app
            app.UseLogExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Example middleware finalizador
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Bienvenidos al curso de .NET Core");
            //});

            //Example middleware 
            app.Use(async (context, next) =>
            {
                var watch = Stopwatch.StartNew();

                await next();

                Debug.WriteLine($"{watch.ElapsedMilliseconds}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
