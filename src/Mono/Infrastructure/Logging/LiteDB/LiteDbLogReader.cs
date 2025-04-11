using Integrador.Infrastructure.Logging.Shared;

using LiteDB;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using var db = new LiteDatabase(_connectionString);
            var col = db.GetCollection<LogEntry>("Log");

            col.EnsureIndex(x => x.Timestamp);
            col.EnsureIndex(x => x.Level);

            InitializeIfEmpty(col);

            // Materializamos los datos ANTES de cerrar la conexión
            var lista = col.FindAll()
                           .OrderByDescending(e => e.Timestamp)
                           .ToList(); // <- Esto es clave

            return lista;
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
