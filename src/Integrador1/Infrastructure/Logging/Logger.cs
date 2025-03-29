using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Logging;

public class Logger : ILogger
{
    public void LogError(Exception ex, string message)
    {
        var logMessage = $"[{DateTime.Now}] ERROR: {message} - Excepción: {ex.GetType().Name}, Mensaje: {ex.Message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }

    public void LogInformation(string message)
    {
        var logMessage = $"[{DateTime.Now}] INFO: {message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }
}
