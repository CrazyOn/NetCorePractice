using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace NetCorePractice.Configuration._3._0
{
    public class MultiObjectConfiguration : IRun, IDisplayNone
    {
        public void Run()
        {
            IConfiguration configuration =
                new ConfigurationBuilder().Add(new MemoryConfigurationSource
                {
                    InitialData = new Dictionary<string, string>
                    {
                        ["Profile:Gender"] = "Male",
                        ["Profile:Age"] = "18",
                        ["Profile:ContactInfo:Email"] = "foobar@outlook.com",
                        ["Profile:ContactInfo:PhoneNo"] = "123456789",
                    }
                }).Build();

            Profile profile = configuration.Get<Profile>("Profile");
            Console.WriteLine("{0,-10}:{1}", "Gender", profile.Gender);
            Console.WriteLine("{0,-10}:{1}", "Age", profile.Age);
            Console.WriteLine("{0,-10}:{1}", "Email", profile.ContactInfo.Email);
            Console.WriteLine("{0,-10}:{1}", "PhoneNo", profile.ContactInfo.PhoneNo);
        }
    }
}
