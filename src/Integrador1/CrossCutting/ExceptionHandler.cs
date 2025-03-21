namespace Integrador.CrossCutting;

public static class ExceptionHandler
{
    public static void HandleException(string mensaje, Exception ex)
    {
        Logger.LogError(mensaje, ex);
        Messenger.MostrarError(mensaje, ex);
    }
}
