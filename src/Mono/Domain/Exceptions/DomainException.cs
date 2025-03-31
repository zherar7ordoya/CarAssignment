namespace Integrador.Domain.Exceptions;

public class DomainException : Exception
{
    public IReadOnlyList<string> Errors { get; }

    // Constructor para un solo error
    public DomainException(string error) : base(error)
    {
        Errors = [error];
    }

    // Constructor para múltiples errores
    public DomainException(IEnumerable<string> errors) : base("Errores de dominio")
    {
        Errors = errors.ToList().AsReadOnly();
    }

    // Constructor para errores con excepción interna
    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = [message];
    }

    // Sobrescribe Message para incluir todos los errores
    public override string Message =>
        Errors.Any() ? $"Errores de dominio: {string.Join(", ", Errors)}" : base.Message;
}
