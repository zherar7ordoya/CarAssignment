using Serilog;
using Serilog.Events;



namespace Integrador.Infrastructure.Logging;

public class SerilogAdapter : ILogger
{
    private readonly Serilog.ILogger _logger;

    public SerilogAdapter()
    {
        _logger = Log.ForContext<SerilogAdapter>();
    }

    public void LogInfo(string message)
    {
        _logger.Information(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    // Añade más métodos según el ILogger actual
    public static void LogError(Exception ex, string message)
    {
        var logMessage = $"[{DateTime.Now}] ERROR: {message} - Excepción: {ex.GetType().Name}, Mensaje: {ex.Message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }

    public static void LogInformation(string message)
    {
        var logMessage = $"[{DateTime.Now}] INFO: {message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }

    public void Write(LogEvent logEvent)
    {
        throw new NotImplementedException();
    }
}
