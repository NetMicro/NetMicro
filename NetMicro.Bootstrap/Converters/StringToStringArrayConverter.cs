using System;
using NFlags.TypeConverters;

namespace NetMicro.Bootstrap.Converters
{
    public class StringToStringArrayConverter : IArgumentConverter
    {
        public bool CanConvert(Type type)
        {
            return type == typeof(string);
        }

        public object Convert(Type type, string value)
        {
            return value.Split(";", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}