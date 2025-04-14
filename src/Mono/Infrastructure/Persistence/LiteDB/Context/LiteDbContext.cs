using System.Configuration;
using LiteDB;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Interfaces.Persistence;

namespace Integrador.Infrastructure.Persistence.LiteDB.Context;

public class LiteDbContext<T>() : ILiteDbContext<T> where T : IEntity
{
    private static readonly string _connectionString = GetConnectionString();
    private static readonly string _databasePath = GetDatabasePath();
    public string CollectionName => typeof(T).Name;

    public LiteDatabase GetDatabase()
    {
        EnsureDatabaseExists();
        return new LiteDatabase(_connectionString);
    }

    /* ////////////////////////////////////////////////////////////////////// */

    private static string GetConnectionString()
    {
        var config = ConfigurationManager.ConnectionStrings["LiteDbBusinessConnection"];
        return config == null
            ? throw new InvalidOperationException("LiteDB connection string not found.")
            : config.ConnectionString;
    }

    private static string GetDatabasePath()
    {
        // Para asegurarnos que el archivo esté en el path correcto
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionString);
    }

    private static void EnsureDatabaseExists()
    {
        var fullPath = GetDatabasePath();
        if (!File.Exists(fullPath))
        {
            using var db = new LiteDatabase(fullPath);
            db.Checkpoint();
        }
    }
}
