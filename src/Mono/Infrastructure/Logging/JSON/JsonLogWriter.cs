using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;

using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Integrador.Infrastructure.Logging.JSON;

public class JsonLogWriter : ILogWriter
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new() { WriteIndented = true };

    public JsonLogWriter()
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

    public void Write(LogEntry entry)
    {
        try
        {
            List<LogEntry> logs;

            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                logs = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? [];
            }
            else
            {
                logs = [];
            }

            logs.Add(entry);

            string updatedJson = JsonSerializer.Serialize(logs, CachedJsonSerializerOptions);
            File.WriteAllText(_filePath, updatedJson);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error writing JSON log: {ex.Message}");
        }
    }
}
