namespace Integrador.Infrastructure.Interfaces;

public interface ILogger
{
    void LogError(Exception ex, string message);
    void LogInformation(string message);
}
