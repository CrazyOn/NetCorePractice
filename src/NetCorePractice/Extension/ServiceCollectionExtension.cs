using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NetCorePractice.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddSingletonAllAssignableFrom(this ServiceCollection services, Type service, Type[] ignoreTypes = null)
        {
            IEnumerable<Type> allTypes = Assembly.GetEntryAssembly().GetTypes();

            ignoreTypes?.ToList().ForEach(ignoreType =>
            {
                allTypes = allTypes.Where(implementationType => !ignoreType.IsAssignableFrom(implementationType));
            });

            allTypes.Where(implementationType => service.FullName != implementationType.FullName)
                .Where(service.IsAssignableFrom)
                .OrderBy(sort => sort.Namespace).ToList().ForEach(implementationType =>
                {
                    services.AddSingleton(service, implementationType);
                });
        }
    }
}
