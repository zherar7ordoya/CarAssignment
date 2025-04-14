using Integrador.Infrastructure.Interfaces;

using System.Diagnostics;

namespace Integrador.Infrastructure.Logging.Shared;

public class Logger(params IEnumerable<ILogWriter> writers) : ILogger
{
    public void LogInformation(string message) => Log(LogLevel.Information, message);
    public void LogError(string message) => Log(LogLevel.Error, message);
    public void LogError(Exception ex) => Log(LogLevel.Error, ex.Message, ex);
    public void LogError(Exception ex, string message) => Log(LogLevel.Error, message, ex);

    private void Log(LogLevel nivel, string mensaje, Exception? ex = null)
    {
        var entry = new LogEntry
        {
            Timestamp = DateTime.Now,
            Level = nivel,
            Message = mensaje,
            StackTrace = ex?.ToString(),
            Source = GetCallerName()
        };

        foreach (var writer in writers)
        {
            writer.Write(entry);
        }
    }

    private static string? GetCallerName()
    {
        var method = new StackTrace().GetFrame(3)?.GetMethod();
        return $"{method?.DeclaringType?.Name}.{method?.Name}";
    }

    public void TryLog(string message, Exception? ex = null)
    {
        try { Log(ex == null ? LogLevel.Information : LogLevel.Error, message, ex); }
        catch (Exception loggingEx) { Debug.WriteLine($"Logging error: {loggingEx.Message}"); }
    }
}
