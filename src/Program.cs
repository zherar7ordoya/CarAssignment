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
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new ViewForm());
            }
            catch (Exception ex)
            {
                Service.LogError("Error al iniciar la aplicaci�n", ex);
                MessageBox.Show("Error al iniciar la aplicaci�n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}