namespace Integrador.Application.Exceptions;

public class ApplicationException : Exception
{
    public IReadOnlyList<string> Errors { get; }

    // Constructor para un solo error
    public ApplicationException(string error) : base(error)
    {
        Errors = [error];
    }

    // Constructor para múltiples errores
    public ApplicationException(IEnumerable<string> errors) : base("Errores de aplicación")
    {
        Errors = errors.ToList().AsReadOnly();
    }

    // Constructor para errores con excepción interna
    public ApplicationException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = [message];
    }

    // Sobrescribe Message para incluir todos los errores
    public override string Message =>
        Errors.Any() ? $"Errores de aplicación: {string.Join(", ", Errors)}" : base.Message;
}
