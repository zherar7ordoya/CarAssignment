namespace Integrador.CrossCutting;

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
            Exceptor.HandleException($"Error al validar el objeto {typeof(T).Name}", ex);
            return false;
        }
    }
}
