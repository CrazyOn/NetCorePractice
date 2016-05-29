using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCorePractice.Configuration._1._0
{
    public class OptionCurrencyDecimalFormatSettings
    {
        public int Digits { get; set; }
        public string Symbol { get; set; }
    }
}
