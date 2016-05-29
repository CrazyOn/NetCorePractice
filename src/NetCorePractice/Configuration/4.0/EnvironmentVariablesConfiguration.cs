using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using NetCorePractice.Configuration._3._0;

namespace NetCorePractice.Configuration._4._0
{
    public class EnvironmentVariablesConfiguration : IRun, IDisplayNone
    {
        public void Run()
        {
            Environment.SetEnvironmentVariable("Profile:Gender", "Male");
            Environment.SetEnvironmentVariable("Profile:Age", "18");
            Environment.SetEnvironmentVariable("Profile:ContactInfo:Email", "foobar@outlook.com");
            Environment.SetEnvironmentVariable("Profile:ContactInfo:PhoneNo", "123456789");
            Profile profile = new ConfigurationBuilder()
            //.Add(new EnvironmentVariablesConfigurationSource("Profile:"))
            .AddEnvironmentVariables("Profile:")
            .Build()
            .Get<Profile>();

            Console.WriteLine("{0,-10}:{1}", "Gender", profile.Gender);
            Console.WriteLine("{0,-10}:{1}", "Age", profile.Age);
            Console.WriteLine("{0,-10}:{1}", "Email", profile.ContactInfo.Email);
            Console.WriteLine("{0,-10}:{1}", "PhoneNo", profile.ContactInfo.PhoneNo);
        }
    }

    public class EnvironmentVariablesConfigurationSource : MemoryConfigurationSource
    {
        private readonly string _prefix;
        public EnvironmentVariablesConfigurationSource(string prefix = null)
        {
            _prefix = prefix ?? string.Empty;
        }

        protected void Inital()
        {
            InitialData = Environment.GetEnvironmentVariables()
                .Cast<DictionaryEntry>()
                .Where(it => it.Key.ToString().StartsWith(_prefix, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(it => it.Key.ToString().Substring(_prefix.Length), it => it.Value.ToString());
        }
    }

    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEnvironment(this IConfigurationBuilder builder,string prefix)
        {
            return builder.Add(new EnvironmentVariablesConfigurationSource(prefix));
        }
    }

    //public class EnvironmentVariablesConfigurationProvider : ConfigurationProvider
    //{
    //    private readonly string _prefix;
    //    public EnvironmentVariablesConfigurationProvider(string prefix = null)
    //    {
    //        _prefix = prefix ?? string.Empty;
            
    //    }

    //    public override void Load()
    //    {
    //        var dictionary = Environment.GetEnvironmentVariables()
    //            .Cast<DictionaryEntry>()
    //            .Where(it => it.Key.ToString().StartsWith(_prefix, StringComparison.OrdinalIgnoreCase))
    //            .ToDictionary(it => it.Key.ToString().Substring(_prefix.Length), it => it.Value.ToString());
    //        Data= new Dictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase);
    //    }
    //}
}
