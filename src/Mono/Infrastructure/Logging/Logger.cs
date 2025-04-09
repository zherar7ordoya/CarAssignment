using Integrador.Application.Interfaces.Infrastructure;

namespace Integrador.Infrastructure.Logging;

public class Logger : ILogger
{
    private static readonly string _logTxt = "Log.txt";

    /*
     * El catch dentro de TryLog queda vacío a propósito para evitar que un error
     * en el logger o en su configuración oculte errores más importantes. Es una
     * práctica común que evita que los errores de logging generen más problemas.
     */
    public void TryLog(string message, Exception? ex = null)
    {
        try
        {
            if (ex is null) LogInformation(message);
            else LogError(ex, message);
        }
        catch (Exception logEx)
        {
            System.Diagnostics.Debug.WriteLine($"Logging error: {logEx.Message}");
        }
    }

    /* ////////////////////////////////////////////////////////////////////// */

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
