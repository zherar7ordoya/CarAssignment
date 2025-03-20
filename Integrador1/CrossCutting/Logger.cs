namespace Integrador.CrossCutting;

public static class Logger
{
    public static void LogError(string message, Exception ex)
    {
        var logMessage = $"[{DateTime.Now}] {message} - Excepción: {ex.GetType().Name}, Mensaje: {ex.Message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }
}
