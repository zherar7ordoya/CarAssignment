using ILogger = Integrador.Application.Interfaces.ILogger;

using Microsoft.Extensions.Logging;

namespace Integrador.Application.Logging;

public class Logger : ILogger
{
    private static readonly string _logTxt = "Log.txt";

    public void LogError(Exception ex)
    {
        LogError(ex, "Excepción capturada.");
    }

    public void LogError(string message)
    {
        LogError(new Exception(message), "Excepción capturada.");
    }

    public void LogError(Exception ex, string message)
    {
        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message} - {ex.GetType().Name}: {ex.Message}";
        File.AppendAllText(_logTxt, logMessage + Environment.NewLine);
    }

    public void LogInformation(string message)
    {
        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}";
        File.AppendAllText(_logTxt, logMessage + Environment.NewLine);
    }
}
