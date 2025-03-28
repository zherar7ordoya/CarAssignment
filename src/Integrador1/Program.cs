using Integrador.Shared.Exceptions;

namespace Integrador;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();

            // Para evitar conflictos con el nombre del namespace "Application".
            System.Windows.Forms.Application.Run(new ViewForm());
        }
        catch (Exception ex) { ExceptionHandler.HandleException("Error al iniciar la aplicación", ex); }
    }
}
