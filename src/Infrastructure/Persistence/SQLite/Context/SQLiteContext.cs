using CarAssignment.Infrastructure.Interfaces.Persistence;

using Microsoft.Data.Sqlite;

using System.Configuration;
using System.Reflection;

namespace CarAssignment.Infrastructure.Persistence.SQLite.Context;

public class SQLiteContext<T>() : ISQLiteContext<T>
{
    static SQLiteContext()
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
        var config = ConfigurationManager.ConnectionStrings["SQLiteBusinessConnection"];
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
        {
            var innerType = type.GetGenericArguments()[0];

            // Se almacenará como string de ids separados por coma
            if (innerType == typeof(int) || innerType == typeof(long)) return "TEXT";

            // Otros tipos de listas no se persisten
            return null!;

            /*
             * PROVISORIO: Creo que, más que evaluar si es un int, debería
             * evaluar si no es un tipo primitivo.
             */
        }

        return type switch
        {
            _ when type == typeof(int) => "INTEGER",
            _ when type == typeof(long) => "INTEGER",
            _ when type == typeof(decimal) => "REAL",
            _ when type == typeof(double) => "REAL",
            _ when type == typeof(string) => "TEXT",
            _ when type == typeof(bool) => "INTEGER", // 0 o 1
            _ when type == typeof(DateTime) => "TEXT",
            _ => "TEXT"
        };
    }
}
