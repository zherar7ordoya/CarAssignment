using CarAssignment.Infrastructure.Interfaces;
using CarAssignment.Infrastructure.Logging.Shared;

using LiteDB;

using System.Configuration;

namespace CarAssignment.Infrastructure.Logging.LiteDB;

public class LiteDbLogWriter : ILogWriter
{
    private readonly string _connectionString;

    public LiteDbLogWriter()
    {
        var connectionStringSetting = ConfigurationManager.ConnectionStrings["LiteDbLogConnection"];

        if (connectionStringSetting == null || string.IsNullOrWhiteSpace(connectionStringSetting.ConnectionString))
        {
            throw new InvalidOperationException("String connection (LiteDbLogConnection) missing in App.config.");
        }

        _connectionString = connectionStringSetting.ConnectionString;
    }

    public void Write(LogEntry entry)
    {
        using var db = new LiteDatabase(_connectionString);
        var col = db.GetCollection<LogEntry>("Log");
        col.Insert(entry);
    }
}
