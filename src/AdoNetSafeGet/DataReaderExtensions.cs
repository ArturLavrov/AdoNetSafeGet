using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoNetSafeGet
{
    public static class DataReaderExtensions
    {
        public static Int16 SafeGetInt16(this IDataReader dataReader, string columnName, Int16 defaultValue = default(Int16))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetInt16(columnIndex);
            }
            return defaultValue;
        }

        public static Int32 SafeGetInt32(this IDataReader dataReader, string columnName, Int32 defaultValue = default(Int32))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetInt32(columnIndex);
            }
            return defaultValue;
        }

        public static Int64 SafeGetInt64(this IDataReader dataReader, string columnName, Int64 defaultValue = default(Int64))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetInt64(columnIndex);
            }
            return defaultValue;
        }

        public static Decimal SafeGetDecimal(this IDataReader dataReader, string columnName, decimal defaultValue = default(Decimal))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetDecimal(columnIndex);
            }
            return defaultValue;
        }

        public static char SafeGetChar(this IDataReader dataReader, string columnName, char defaultValue = default(Char))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetChar(columnIndex);
            }
            return defaultValue;
        }

        public static byte SafeGetByte(this IDataReader dataReader, string columnName, byte defaultValue = default(Byte))
        {
            int columnIndex = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(columnIndex))
            {
                return dataReader.GetByte(columnIndex);
            }
            return defaultValue;
        }

        public static string SafeGetString(this IDataReader dataReader, string columnName, string defaultValue = default(String))
        {
            int index = dataReader.GetOrdinal(columnName);
            if (!dataReader.IsDBNull(index))
            {
                return dataReader.GetString(index);
            }
            return defaultValue;
        }

        public static string SafeGetDateTimeAsFormatedString(this IDataReader datareader, string columnName, string defaultValue = default(string), string dateTimeFormat = "")
        {

            int index = datareader.GetOrdinal(columnName);
            if (!datareader.IsDBNull(index))
            {
                return datareader.GetDateTime(index).ToString(dateTimeFormat);
            }
            return defaultValue;
        }
    }
}
