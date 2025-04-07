using Integrador.Application.Interfaces;
using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace Integrador.Infrastructure.Persistence.SQLite;

public class SQLiteDataSource<T>() : ISQLiteDataSource<T>
{
    private static readonly string _connectionString = LoadConnectionString();
    public string TableName => typeof(T).Name;

    public SqliteConnection GetOpenConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }

    private static string LoadConnectionString()
    {
        var config = ConfigurationManager.ConnectionStrings["SQLiteConnection"];
        return config == null
            ? throw new InvalidOperationException("Connection string not found.")
            : config.ConnectionString;
    }
}
