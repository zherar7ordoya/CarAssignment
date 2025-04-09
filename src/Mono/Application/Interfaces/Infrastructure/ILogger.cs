namespace Integrador.Application.Interfaces.Infrastructure;

public interface ILogger
{
    void TryLog(string message, Exception? ex = null);
    void LogError(Exception ex);
    void LogError(string message);
    void LogError(Exception ex, string message);
    void LogInformation(string message);
}
