using System.Data.SqlTypes;

namespace DataAccess
{
    public abstract class DataReaderDelegate<T> : DataDelegate, IDataReaderDelegate<T>
    {
        protected DataReaderDelegate(string procedureName)
           : base(procedureName)
        {
        }

        public abstract T Translate(SqlCommandExecutor command, IDataRowReader reader);
    }
}