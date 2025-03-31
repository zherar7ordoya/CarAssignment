namespace Integrador.Infrastructure.Exceptions;

public class InfrastructureException(string message, Exception innerException)
           : Exception(message, innerException)
{
}
