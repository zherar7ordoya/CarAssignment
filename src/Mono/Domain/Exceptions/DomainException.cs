namespace Integrador.Domain.Exceptions;

public class DomainException : Exception
{
    public List<string> Errors { get; }

    public DomainException(string message) : base(message)
    {
        Errors = [message];
    }

    public DomainException(List<string> errors)
    {
        Errors = errors;
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = [message];
    }

    public override string Message => $"Errores de dominio: {string.Join(", ", Errors)}";
}