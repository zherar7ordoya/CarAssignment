using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;

using LiteDB;

using System.Configuration;
using System.Diagnostics;

namespace Integrador.Infrastructure.Logging.LiteDB;

public class LiteDbLogReader : ILogReader
{
    private readonly string _connectionString;

    public LiteDbLogReader()
    {
        var connectionStringSetting = ConfigurationManager.ConnectionStrings["LiteDbLogConnection"];
        if (connectionStringSetting == null || string.IsNullOrWhiteSpace(connectionStringSetting.ConnectionString))
        {
            throw new InvalidOperationException("String connection (LiteDbLogConnection) missing in App.config.");
        }
        _connectionString = connectionStringSetting.ConnectionString;
    }

    public IEnumerable<LogEntry> Read()
    {
        try
        {
            using var database = new LiteDatabase(_connectionString);
            var collection = database.GetCollection<LogEntry>("Log");

            collection.EnsureIndex(x => x.Timestamp);
            collection.EnsureIndex(x => x.Level);

            InitializeIfEmpty(collection);

            // Materializamos los datos ANTES de cerrar la conexión
            var entries = collection.FindAll()
                           .OrderByDescending(e => e.Timestamp)
                           .ToList(); // <- Esto es clave

            return entries;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading logs: {ex.Message}");
            return [];
        }
    }

    private static void InitializeIfEmpty(ILiteCollection<LogEntry> col)
    {
        if (!col.Exists(Query.All()))
        {
            col.Insert(new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = LogLevel.Information,
                Message = "Welcome log."
            });
        }
    }
}
