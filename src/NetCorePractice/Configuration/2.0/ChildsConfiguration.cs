using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace NetCorePractice.Configuration._2._0
{
    public class ChildsConfiguration: IRun, IDisplayNone
    {
        public void Run()
        {
            Dictionary<string, string> source = new Dictionary<string, string>
            {
                ["A:B:C"] = "",
                ["A:B:D"] = "",
                ["A:E"] = "",
            };
            //MemoryConfigurationSource provider = new MemoryConfigurationSource {InitialData = source};
            MemoryConfigurationProvider provider = new MemoryConfigurationProvider(new MemoryConfigurationSource { InitialData = source });
            Console.WriteLine("{0, -20}{1}", "Parent Path", "Child Keys");
            Console.WriteLine("------------------------------------------");

            Print("Null", provider.GetChildKeys(new string[] { "X", "Y", "Z" }, null));
            Print("A", provider.GetChildKeys(new string[] { "x", "y", "z" }, "A"));
            Print("A:B", provider.GetChildKeys(new string[] { "X", "Y", "Z" }, "A:B"));
            Print("A:B:C", provider.GetChildKeys(new string[] { "X", "Y", "Z" }, "A:B:C"));
        }

        static void Print(string parentPath, IEnumerable<string> keys)
        {
            Console.WriteLine("{0, -20}{1}", parentPath, string.Join(", ", keys.ToArray()));
        }
    }
}
