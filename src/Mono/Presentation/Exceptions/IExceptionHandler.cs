namespace Integrador.Presentation.Exceptions;

public interface IExceptionHandler
{
    void Handle(Exception ex);
    void Handle(Exception ex, string message);
}
