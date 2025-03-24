namespace Integrador.CrossCutting;

public static class ExceptionHandler
{
    public static void HandleException(string mensaje, Exception ex)
    {
        Logger.LogError(mensaje, ex);
        Messenger.MostrarError(mensaje, ex);
    }

    public static (bool Success, Exception? Error) Execute(Action action, string errorMessage = "Error en la operación.")
    {
        try
        {
            action();
            return (true, null);
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(errorMessage, ex);
            return (false, ex);
        }
    }

    public static (bool Success, Exception? Error) Execute(Func<(bool, Exception?)> function, string errorMessage = "Error en la operación.")
    {
        try
        {
            return function();
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(errorMessage, ex);
            return (false, ex);
        }
    }
}
