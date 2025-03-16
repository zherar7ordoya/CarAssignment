namespace Integrador.Persistence;

public class PersisterException(string message,
                                Exception innerException) : Exception(message, innerException)
{
}
