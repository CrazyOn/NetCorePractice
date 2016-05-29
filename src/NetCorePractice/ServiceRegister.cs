using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetCorePractice.Extension;

namespace NetCorePractice
{
    public class ServiceRegister
    {
        public static ServiceCollection Register()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingletonAllAssignableFrom(typeof(IRun), ignoreTypes: new[] { typeof(IDisplayNone) });

            return services;
        }
    }


}
