using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;

using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Integrador.Infrastructure.Logging.JSON;

public class JsonLogReader : ILogReader
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new() { WriteIndented = true };

    public JsonLogReader()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonLogPath"];
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "LogEntry.json");
        EnsureFolderExists();
    }

    private void EnsureFolderExists()
    {
        var folderPath = Path.GetDirectoryName(_filePath);

        if (folderPath != null && !Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public IEnumerable<LogEntry> Read()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Seed();
            }

            string json = File.ReadAllText(_filePath);
            var logs = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? [];

            return [.. logs.OrderByDescending(e => e.Timestamp)];
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading JSON logs: {ex.Message}");
            return [];
        }
    }

    private void Seed()
    {
        var welcomeLog = new List<LogEntry>
        {
            new()
            {
                Timestamp = DateTime.Now,
                Level = LogLevel.Information,
                Message = "Welcome log."
            }
        };

        string json = JsonSerializer.Serialize(welcomeLog, CachedJsonSerializerOptions);
        File.WriteAllText(_filePath, json);
    }
}

