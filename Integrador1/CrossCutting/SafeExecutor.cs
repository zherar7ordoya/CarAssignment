namespace Integrador.CrossCutting;

public static class SafeExecutor
{
    // Método genérico para operaciones que no devuelven valor.
    public static (bool Success, string ErrorMessage) Execute(Action action)
    {
        try
        {
            action();
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException("Error en la operación.", ex);
            return (false, ex.Message);
        }
    }

    // Sobrecarga para métodos que sí devuelven valor.
    public static (bool Success, T? Result, string ErrorMessage) Execute<T>(Func<T> function)
    {
        try
        {
            var result = function();
            return (true, result, string.Empty);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException("Error en la operación.", ex);
            return (false, default, ex.Message);
        }
    }
}
