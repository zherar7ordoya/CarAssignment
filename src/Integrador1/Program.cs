using Integrador.CrossCutting;

namespace Integrador
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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
}
