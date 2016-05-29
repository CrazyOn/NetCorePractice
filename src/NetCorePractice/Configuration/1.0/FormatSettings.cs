using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCorePractice.Configuration._1._0
{
    public class FormatSettings
    {
        public DateTimeFormatSettings DateTime { get; set; }
        public CurrencyDecimalFormatSettings CurrencyDecimal { get; set; }

        public FormatSettings(IConfiguration configuration)
        {
            this.DateTime = new DateTimeFormatSettings(configuration.GetSection("DateTime"));
            this.CurrencyDecimal = new CurrencyDecimalFormatSettings(configuration.GetSection("CurrencyDecimal"));
        }
    }
}
