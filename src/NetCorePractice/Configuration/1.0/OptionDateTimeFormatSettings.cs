using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCorePractice.Configuration._1._0
{
    public class OptionDateTimeFormatSettings
    {
        public string LongDatePattern { get; set; }
        public string LongTimePattern { get; set; }
        public string ShortDatePattern { get; set; }
        public string ShortTimePattern { get; set; }
    }
}
