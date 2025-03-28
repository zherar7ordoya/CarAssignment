namespace Integrador.Infrastructure.Logging;

public static class Logger
{
    public static void LogError(string message, Exception ex)
    {
        var logMessage = $"[{DateTime.Now}] ERROR: {message} - Excepción: {ex.GetType().Name}, Mensaje: {ex.Message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }

    public static void LogInfo(string message)
    {
        var logMessage = $"[{DateTime.Now}] INFO: {message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }
}
