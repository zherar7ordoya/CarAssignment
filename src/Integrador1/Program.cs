using Integrador.Infrastructure;

namespace Integrador;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ViewForm());
        }
        catch (Exception ex) { ExceptionHandler.HandleException("Error al iniciar la aplicación", ex); }
    }
}
