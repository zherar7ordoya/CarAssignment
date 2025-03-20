namespace Integrador.CrossCutting;

public static class Exceptor
{
    public static void HandleException(string mensaje, Exception ex)
    {
        Logger.LogError(mensaje, ex);
        Messenger.MostrarError(mensaje, ex);
    }
}
