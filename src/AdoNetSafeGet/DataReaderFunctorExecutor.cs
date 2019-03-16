using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Text;

namespace AdoNetSafeGet
{
    internal static class DataReaderFunctorExecutor<T>
    {
        public static T ExecuteFunction<T>(IDataReader dataReader, int columnIndex, Func<T> func, T defaultValue = default(T))
        {
            if (!dataReader.IsDBNull(columnIndex))
            {
                return func();
            }
            return defaultValue;
        }
    }
}
