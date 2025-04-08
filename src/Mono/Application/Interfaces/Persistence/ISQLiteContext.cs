using Microsoft.Data.Sqlite;

namespace Integrador.Application.Interfaces.Persistence;

public interface ISQLiteContext<T>
{
    SqliteConnection GetConnection();
    string TableName { get; }
}
