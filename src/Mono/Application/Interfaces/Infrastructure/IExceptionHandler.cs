namespace Integrador.Application.Interfaces.Infrastructure;

public interface IExceptionHandler
{
    void Handle(Exception ex);
    void Handle(string message);
    void Handle(Exception ex, string message);
}
