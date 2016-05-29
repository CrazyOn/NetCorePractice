using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace NetCorePractice.Configuration._1._0
{
    public class KeyValueConfiguration : IRun, IDisplayNone
    {
        public void Run()
        {
            var source = new Dictionary<string, string>
            {
                ["LongDatePattern"] = "dddd, MMMM d, yyyy",
                ["LongTimePattern"] = "h:mm:ss tt",
                ["ShortDatePattern"] = "M/d/yyyy",
                ["ShortTimePattern"] = "h:mm tt"
            };

            //// Microsoft.Extensions.Configuration(1.0.0-rc1-final)
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .Add(new MemoryConfigurationProvider(source))
            //    .Build();

            // Microsoft.Extensions.Configuration(1.0.0-rc2-final)
            IConfiguration configuration = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource { InitialData = source })
                .Build();

            var settings = new DateTimeFormatSettings(configuration);
            Console.WriteLine("{0,-16}: {1}", "LongDatePattern", settings.LongDatePattern);
            Console.WriteLine("{0,-16}: {1}", "LongTimePattern", settings.LongTimePattern);
            Console.WriteLine("{0,-16}: {1}", "ShortDatePattern", settings.ShortDatePattern);
            Console.WriteLine("{0,-16}: {1}", "ShortTimePattern", settings.ShortTimePattern);
        }
    }
}
