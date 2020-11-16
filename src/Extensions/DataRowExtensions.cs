using System;
using System.Data;

namespace Extensions
{
    public static class DataRowExtensions
    {
        public static DataPoint DataPoint(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return new DataPoint(o);
        }

        public static bool? GetBooleanOrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return o == null || o == DBNull.Value
                ? (bool?)null
                : Convert.ToBoolean(o);
        }

        public static DateTime? GetDateTimeOrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return o == null || o == DBNull.Value || Convert.ToString(o) == string.Empty
                ? (DateTime?)null
                : Convert.ToDateTime(o);
        }

        public static decimal? GetDecimalOrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return o == null || o == DBNull.Value
                ? (decimal?)null
                : Convert.ToDecimal(o);
        }

        public static int? GetInt32OrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return o == null || o == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(o);
        }

        public static long? GetInt64OrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return o == null || o == DBNull.Value
                ? (long?)null
                : Convert.ToInt64(o);
        }

        public static string GetStringOrNull(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            if (o == null || o == DBNull.Value || o.ToString() == string.Empty || o.ToString().ToLower() == "null")
                return null;

            return o.ToString();
        }

        public static bool GetSafeBoolean(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o != null && o != DBNull.Value && Convert.ToString(o) != string.Empty) && Convert.ToBoolean(o);
        }

        public static DateTime GetSafeDateTime(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o == null || o == DBNull.Value || Convert.ToString(o) == string.Empty)
                ? DateTime.MinValue
                : Convert.ToDateTime(o);
        }

        public static decimal GetSafeDecimal(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o == null || o == DBNull.Value)
                ? 0
                : Convert.ToDecimal(o);
        }

        public static int GetSafeInt32(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o == null || o == DBNull.Value)
                ? 0
                : Convert.ToInt32(o);
        }

        public static long GetSafeInt64(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o == null || o == DBNull.Value)
                ? 0
                : Convert.ToInt64(o);
        }

        public static string GetSafeString(this DataRow dataRow, string columnName)
        {
            object o = dataRow[columnName];

            return (o == null || o == DBNull.Value)
                ? string.Empty
                : o.ToString();
        }
    }

    public class DataPoint
    {
        public object Value { get; }

        public DataPoint(object value)
        {
            Value = value;
        }

        public T GetValue<T>()
        {
            return (T)Value;
        }

        public T GetValueOrDefault<T>()
        {
            if (IsNull)
            {
                return default;
            }

            return (T)Value;
        }

        public bool IsNull => Value == null || Value == DBNull.Value;
    }
}
