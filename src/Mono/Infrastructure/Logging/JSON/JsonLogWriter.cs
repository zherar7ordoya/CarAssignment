using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;

using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Integrador.Infrastructure.Logging.JSON;

public class JsonLogWriter : ILogWriter
{
    private readonly string _logFilePath;

    public JsonLogWriter()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonLogPath"];
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "LogEntry.json");
    }

    public void Write(LogEntry entry)
    {
        try
        {
            List<LogEntry> logs;

            if (File.Exists(_logFilePath))
            {
                string json = File.ReadAllText(_logFilePath);
                logs = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            else
            {
                logs = new List<LogEntry>();
            }

            logs.Add(entry);

            string updatedJson = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_logFilePath, updatedJson);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error writing JSON log: {ex.Message}");
        }
    }
}
