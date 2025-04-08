using Integrador.Application.Interfaces;

using Microsoft.Data.Sqlite;

using System.Configuration;
using System.Reflection;

namespace Integrador.Infrastructure.Persistence.SQLite;

public class SQLiteDataSource<T>() : ISQLiteDataSource<T>
{
    static SQLiteDataSource()
    {
        EnsureDatabaseAndTable();
    }

    private static readonly string _connectionString = GetString();
    private static readonly string _databasePath = GetDatabasePath();
    public string TableName => typeof(T).Name;

    /* ////////////////////////////////////////////////////////////////////// */

    public SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }

    private static string GetString()
    {
        var config = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
        return config == null
            ? throw new InvalidOperationException("Connection string not found.")
            : config.ConnectionString;
    }

    private static string GetDatabasePath()
    {
        var builder = new SqliteConnectionStringBuilder(_connectionString);
        return builder.DataSource;
    }

    private static void EnsureDatabaseAndTable()
    {
        _ = File.Exists(_databasePath);
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        if (!TableExists(connection))
        {
            var createTableSql = GenerateCreateTableSql(typeof(T));
            using var command = new SqliteCommand(createTableSql, connection);
            command.ExecuteNonQuery();
        }
    }

    private static bool TableExists(SqliteConnection connection)
    {
        var tableName = typeof(T).Name;
        var sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();
        return reader.Read(); // true si hay resultados
    }

    private static string GenerateCreateTableSql(Type type)
    {
        var columns = type
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Select(prop => new { prop.Name, SqlType = MapToSqliteType(prop.PropertyType) })
        .Where(x => x.SqlType != null)
        .Select(x => $"{x.Name} {x.SqlType}");

        var columnsDef = string.Join(", ", columns);
        return $"CREATE TABLE IF NOT EXISTS {type.Name} ({columnsDef})";
    }

    private static string MapToSqliteType(Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            return null!; // Las listas no deben ser persistidas así

        return type switch
        {
            _ when type == typeof(int) => "INTEGER",
            _ when type == typeof(long) => "INTEGER",
            _ when type == typeof(decimal) => "REAL",
            _ when type == typeof(double) => "REAL",
            _ when type == typeof(string) => "TEXT",
            _ when type == typeof(bool) => "INTEGER", // 0 o 1
            _ when type == typeof(DateTime) => "TEXT", // se puede parsear luego
            _ => "TEXT"
        };
    }
}
