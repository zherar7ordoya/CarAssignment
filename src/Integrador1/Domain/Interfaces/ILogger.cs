namespace Integrador.Domain.Interfaces;

public interface ILogger
{
    void LogError(string message, Exception ex);
    void LogInformation(string message);
}
