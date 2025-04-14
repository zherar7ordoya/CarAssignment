using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;

using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Integrador.Infrastructure.Logging.JSON;

public class JsonLogReader : ILogReader
{
    private readonly string _logFilePath;

    public JsonLogReader()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonLogPath"];
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "LogEntry.json");
    }

    public IEnumerable<LogEntry> Read()
    {
        try
        {
            if (!File.Exists(_logFilePath))
            {
                InitializeWithWelcomeLog();
            }

            string json = File.ReadAllText(_logFilePath);
            var logs = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();

            return logs.OrderByDescending(e => e.Timestamp).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading JSON logs: {ex.Message}");
            return new List<LogEntry>();
        }
    }

    private void InitializeWithWelcomeLog()
    {
        var welcomeLog = new List<LogEntry>
        {
            new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = LogLevel.Information,
                Message = "Welcome log."
            }
        };

        string json = JsonSerializer.Serialize(welcomeLog, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_logFilePath, json);
    }
}

