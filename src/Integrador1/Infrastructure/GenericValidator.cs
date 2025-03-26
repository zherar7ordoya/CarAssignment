namespace Integrador.Infrastructure;

public class Validator
{
    public static bool Validate<T>(T entity, Action<T> validator)
    {
        try
        {
            validator(entity);
            return true;
        }
        catch (ArgumentException ex)
        {
            ExceptionHandler.HandleException($"Error al validar el objeto {typeof(T).Name}", ex);
            return false;
        }
    }
}
