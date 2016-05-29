using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCorePractice.Configuration._1._0
{
    public class OptionFormatSettings
    {
        public OptionDateTimeFormatSettings DateTime { get; set; }
        public OptionCurrencyDecimalFormatSettings CurrencyDecimal { get; set; }
    }
}
