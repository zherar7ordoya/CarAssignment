using Integrador.Application.Interfaces;

namespace Integrador.Infrastructure.Logging;

public class Logger : ILogger
{
    private static readonly string LogFilePath = "Log.txt";

    public void LogError(Exception ex, string message)
    {
        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message} - {ex.GetType().Name}: {ex.Message}";
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }

    public void LogInformation(string message)
    {
        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}";
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }
}
