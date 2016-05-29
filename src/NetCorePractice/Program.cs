using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace NetCorePractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var items = ServiceRegister.Register().BuildServiceProvider().GetServices<IRun>();
            items.ToList().ForEach(item => { item.Run(); Console.WriteLine(); });
            Console.ReadKey();
        }
    }
}
