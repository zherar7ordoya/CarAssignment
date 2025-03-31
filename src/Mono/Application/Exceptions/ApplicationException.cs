namespace Integrador.Application.Exceptions;

public class ApplicationException(string message, Exception innerException)
           : Exception(message, innerException)
{
}
