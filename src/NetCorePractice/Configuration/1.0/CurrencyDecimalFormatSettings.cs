using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCorePractice.Configuration._1._0
{
    public class CurrencyDecimalFormatSettings
    {
        public int Digits { get; set; }
        public string Symbol { get; set; }

        public CurrencyDecimalFormatSettings(IConfiguration configuration)
        {
            //this.Digits = configuration.Get<int>("Digits");
            this.Digits = configuration.GetSection("Digits").Get<int>();
            this.Symbol = configuration["Symbol"];
        }
    }
}
