namespace Integrador.CrossCutting;

public static class SafeExecutor
{
    public static (bool Success, string ErrorMessage) Execute(Action action, string errorMessage = "Error en la operación.")
    {
        try
        {
            action();
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(errorMessage, ex);
            return (false, ex.Message);
        }
    }

    public static (bool Success, string ErrorMessage) Execute(Func<(bool, string)> function, string errorMessage = "Error en la operación.")
    {
        try
        {
            var (success, funcErrorMessage) = function();
            return (success, funcErrorMessage);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(errorMessage, ex);
            return (false, ex.Message);
        }
    }

    public static (bool Success, T? Result, string ErrorMessage) Execute<T>(Func<T> function, string errorMessage = "Error en la operación.")
    {
        try
        {
            var result = function();
            return (true, result, string.Empty);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(errorMessage, ex);
            return (false, default, ex.Message);
        }
    }
}
