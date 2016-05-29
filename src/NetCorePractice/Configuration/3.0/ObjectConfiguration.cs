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
    public class ObjectConfiguration : IRun, IDisplayNone
    {
        public void Run()
        {
            IConfiguration configuration =
                new ConfigurationBuilder().Add(new MemoryConfigurationSource
                {
                    InitialData = new Dictionary<string, string>
                    {
                        ["point"] = "(1.2,3.4)"
                    }
                }).Build();
            //Debug.Assert(configuration.Get<Point>("point").X == 1.2, "different");
            //Debug.Assert(configuration.Get<Point>("point").Y == 3.4, "different");
        }
    }

    [TypeConverter(typeof(PointTypeConverter))]
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class PointTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string[] split = value.ToString().Split(',');
            return new Point
            {
                X = double.Parse(split[0].TrimStart('(')),
                Y = double.Parse(split[1].TrimEnd(')'))
            };
        }
    }
}
