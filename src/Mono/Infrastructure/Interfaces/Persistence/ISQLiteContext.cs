using Microsoft.Data.Sqlite;

namespace Integrador.Infrastructure.Interfaces.Persistence;

public interface ISQLiteContext<T>
{
    SqliteConnection GetConnection();
    string TableName { get; }
}
