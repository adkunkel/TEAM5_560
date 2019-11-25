

namespace DataAccess
{
    public interface IDataReaderDelegate<out T> : IDataDelegate
    {
        T Translate(SqlCommandExecutor command, IDataRowReader reader);
    }
}