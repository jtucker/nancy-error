using NancyError.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace NancyError
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(TokenMiddleware));
            app.UseNancy();
        }
    }
}