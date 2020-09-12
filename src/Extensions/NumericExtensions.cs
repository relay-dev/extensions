using System;
using System.Globalization;

namespace Extensions
{
    public static class NumericExtensions
    {
        public static string ToSafeString(this int? val, string format = null)
        {
            return val.HasValue
                ? GetFormattedValue(val.Value, format)
                : string.Empty;
        }

        public static string ToSafeString(this double? val, string format = null)
        {
            return val.HasValue
                ? GetFormattedValue(val.Value, format)
                : string.Empty;
        }

        public static string ToSafeString(this decimal? val, string format = null)
        {
            return val.HasValue
                ? GetFormattedValue(val.Value, format)
                : string.Empty;
        }

        public static bool? ToNullableBool(this int? val)
        {
            return val.HasValue
                ? Convert.ToBoolean(val.Value)
                : (bool?)null;
        }

        public static Int16 ToInt16(this int val)
        {
            return Convert.ToInt16(val);
        }

        private static string GetFormattedValue(int val, string format)
        {
            return format == null
                ? val.ToString()
                : val.ToString(format);
        }

        private static string GetFormattedValue(double val, string format)
        {
            return format == null
                ? val.ToString(CultureInfo.InvariantCulture)
                : val.ToString(format);
        }

        private static string GetFormattedValue(decimal val, string format)
        {
            return format == null
                ? val.ToString(CultureInfo.InvariantCulture)
                : val.ToString(format);
        }
    }
}
