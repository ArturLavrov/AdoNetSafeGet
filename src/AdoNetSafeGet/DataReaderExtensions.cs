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
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Int16> func = () => dataReader.GetInt16(columnIndex);
            return DataReaderFunctorExecutor<Int16>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static Int32 SafeGetInt32(this IDataReader dataReader, string columnName, Int32 defaultValue = default(Int32))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Int32> func = () => dataReader.GetInt32(columnIndex);
            return DataReaderFunctorExecutor<Int32>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static Int64 SafeGetInt64(this IDataReader dataReader, string columnName, Int64 defaultValue = default(Int64))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Int64> func = () => dataReader.GetInt64(columnIndex);
            return DataReaderFunctorExecutor<Int64>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static Decimal SafeGetDecimal(this IDataReader dataReader, string columnName, decimal defaultValue = default(Decimal))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Decimal> func = () => dataReader.GetDecimal(columnIndex);
            return DataReaderFunctorExecutor<Decimal>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static Char SafeGetChar(this IDataReader dataReader, string columnName, char defaultValue = default(Char))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Char> func = () => dataReader.GetChar(columnIndex);
            return DataReaderFunctorExecutor<Char>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static Byte SafeGetByte(this IDataReader dataReader, string columnName, byte defaultValue = default(Byte))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<Byte> func = () => dataReader.GetByte(columnIndex);
            return DataReaderFunctorExecutor<Byte>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static String SafeGetString(this IDataReader dataReader, string columnName, string defaultValue = default(String))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<String> func = () => dataReader.GetString(columnIndex);
            return DataReaderFunctorExecutor<String>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static DateTime SafeGetDateTime(this IDataReader dataReader, string columnName, DateTime defaultValue = default(DateTime))
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<DateTime> func = () => dataReader.GetDateTime(columnIndex);
            return DataReaderFunctorExecutor<DateTime>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        public static String SafeGetDateTimeAsFormatedString(this IDataReader dataReader, string columnName, string defaultValue = default(string), string dateTimeFormat = "")
        {
            ChekArgumentAccuracy(columnName);

            int columnIndex = GetColumnIndexByName(dataReader, columnName);
            Func<String> func = () => dataReader.GetDateTime(columnIndex).ToString(dateTimeFormat);
            return DataReaderFunctorExecutor<String>.ExecuteFunction(dataReader, columnIndex, func, defaultValue);
        }

        private static int GetColumnIndexByName(IDataReader dataReader, string columnName)
        {
            return dataReader.GetOrdinal(columnName);
        }

        //TODO: move to separate class method ChekArgumentAccuracy
        private static void ChekArgumentAccuracy(string columnName)
        {
            if (String.IsNullOrEmpty(columnName) && String.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException(String.Format(Constants.ArgumentExceptionMessageTemplate, columnName));
            }
        }
    }
}
