namespace Integrador1.Persistence;

public class PersisterException(string message,
                                Exception innerException) : Exception(message, innerException)
{
}
