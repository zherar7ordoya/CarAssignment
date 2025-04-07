using Microsoft.Data.Sqlite;

namespace Integrador.Application.Interfaces;

public interface ISQLiteDataSource<T>
{
    SqliteConnection GetConnection();
    string TableName { get; }
}
