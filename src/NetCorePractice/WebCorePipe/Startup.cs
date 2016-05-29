using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NetCorePractice.WebCorePipe
{
    public class Startup : IRun
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context => context.Response.WriteAsync("Hello world"));
        }

        public void Run()
        {
            //var host = 
                new WebHostBuilder().UseKestrel().UseStartup<Startup>().Build().Run();
            //host.Run();
        }
    }
}