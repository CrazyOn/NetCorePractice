using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace NetCorePractice.Configuration._1._0
{
    public class OptionConfiguration : IRun
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
            //    .Build().GetSection("Format");

            // Microsoft.Extensions.Configuration(1.0.0-rc2-final)
            IConfiguration configuration = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource { InitialData = source })
                .Build().GetSection("Format");
            var optionsAccessor = new ServiceCollection()
                .AddOptions()
                .Configure<OptionFormatSettings>(configuration)
                .BuildServiceProvider()
                .GetService<IOptions<OptionFormatSettings>>();

            OptionFormatSettings settings = optionsAccessor.Value;

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

    //public static class OptionBindExtensions
    //{
    //    //public static IServiceCollection AddOptionsBind(this IServiceCollection services)
    //    //{
    //    //    return services.AddSingleton(typeof(IOptions<>), typeof(OptionsManager<>));
    //    //}

    //    //public static IServiceCollection ConfigureBind<TOptions>(this IServiceCollection services,
    //    //    IConfiguration configuration)
    //    //    where TOptions : class, new()
    //    //{
    //    //    return services.AddInstance<IConfigureOptions<TOptions>>(new ConfigureFromConfigurationOptionsBind<TOptions>(configuration));
    //    //}
    //}

    //public class ConfigureFromConfigurationOptionsBind<TOptions> : ConfigureOptionsBind<TOptions> where TOptions : class, new()
    //{
    //    public ConfigureFromConfigurationOptionsBind(IConfiguration configuration)
    //        : base(configuration.Bind)
    //    {

    //    }
    //}

    //public class ConfigureOptionsBind<TOptions> : IConfigureOptions<TOptions> where TOptions : class, new()
    //{
    //    public Action<TOptions> Action { get; private set; }

    //    public ConfigureOptionsBind(Action<TOptions> action)
    //    {
    //        this.Action = action;
    //    }

    //    public void Configure(TOptions options)
    //    {
    //        this.Action(options);
    //    }
    //}

    //public class OptionsManagerBind<TOptions> : IOptions<TOptions> where TOptions : class, new()
    //{
    //    private readonly Lazy<TOptions> _optionsAccessor;

    //    public OptionsManagerBind(IConfigureOptions<TOptions> setups)
    //    {
    //        _optionsAccessor = new Lazy<TOptions>(() =>
    //        {
    //            var options = new TOptions();
    //            setups.Configure(options);
    //            return options;
    //        });
    //    }

    //    public TOptions Value => _optionsAccessor.Value;
    //}
}
