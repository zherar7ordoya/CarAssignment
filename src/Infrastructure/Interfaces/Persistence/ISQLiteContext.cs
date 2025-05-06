using Microsoft.Data.Sqlite;

namespace CarAssignment.Infrastructure.Interfaces.Persistence;

public interface ISQLiteContext<T>
{
    SqliteConnection GetConnection();
    string TableName { get; }
}
