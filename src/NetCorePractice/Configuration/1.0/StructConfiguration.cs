using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace NetCorePractice.Configuration._1._0
{
    public class StructConfiguration: IRun, IDisplayNone
    {
        public void Run()
        {
            var source = new Dictionary<string, string>
            {
                ["Format:DateTime:LongDatePattern"] = "dddd, MMMM d, yyyy",
                ["Format:DateTime:LongTimePattern"] = "h:mm:ss tt",
                ["Format:DateTime:ShortDatePattern"] = "M/d/yyyy",
                ["Format:DateTime:ShortTimePattern"] = "h:mm tt",

                ["Format:CurrencyDecimal:Digits"] = "2",
                ["Format:CurrencyDecimal:Symbol"] = "$"
            };

            //// Microsoft.Extensions.Configuration(1.0.0-rc1-final)
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .Add(new MemoryConfigurationProvider(source))
            //    .Build();

            // Microsoft.Extensions.Configuration(1.0.0-rc2-final)
            IConfiguration configuration = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource { InitialData = source })
                .Build();

            var settings = new FormatSettings(configuration.GetSection("Format"));
            Console.WriteLine("DateTime:");
            Console.WriteLine("\t{0,-16}: {1}", "LongDatePattern", settings.DateTime.LongDatePattern);
            Console.WriteLine("\t{0,-16}: {1}", "LongTimePattern", settings.DateTime.LongTimePattern);
            Console.WriteLine("\t{0,-16}: {1}", "ShortDatePattern", settings.DateTime.ShortDatePattern);
            Console.WriteLine("\t{0,-16}: {1}", "ShortTimePattern", settings.DateTime.ShortTimePattern);

            Console.WriteLine("CurrencyDecimal:");
            Console.WriteLine("\t{0,-16}: {1}", "Digits", settings.CurrencyDecimal.Digits);
            Console.WriteLine("\t{0,-16}: {1}", "Symbol", settings.CurrencyDecimal.Symbol);
        }
    }
}
