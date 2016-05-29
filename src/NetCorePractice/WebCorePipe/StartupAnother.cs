using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NetCorePractice.WebCorePipe
{
    public class StartupAnother
    {
        public void Configure(IApplicationBuilder app)
        {
            //app.Run(context => context.Response.WriteAsync("World"));
        }
    }
}
