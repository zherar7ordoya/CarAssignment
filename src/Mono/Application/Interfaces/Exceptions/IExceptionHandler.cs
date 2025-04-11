namespace Integrador.Application.Interfaces.Exceptions;

public interface IExceptionHandler
{
    void Handle(Exception ex);
    void Handle(string message);
    void Handle(Exception ex, string message);
}
