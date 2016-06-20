using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin;

namespace NancyError.Middleware
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OwinFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class TokenMiddleware 
    {
        private OwinFunc next;

        public TokenMiddleware(OwinFunc next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            Guid cToken;
            var context = new OwinContext(env);

            if (!(context.Request.Headers.ContainsKey("Correlation-Token") &&
                 Guid.TryParse(context.Request.Headers["Correlation-Token"], out cToken)))
                cToken = Guid.NewGuid();

            env["correlationToken"] = cToken.ToString();
            await next(env);
        }        
    }
}