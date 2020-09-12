using System;
using System.Data;

namespace Extensions
{
    public static class DataRowExtensions
    {
        public static DataPoint DataPoint(this DataRow dataRow, string columnName)
        {
            object value = dataRow[columnName];

            return new DataPoint(value);
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
