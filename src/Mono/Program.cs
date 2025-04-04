using Microsoft.Extensions.DependencyInjection;
using Integrador.Presentation;
using Integrador;

static class Program
{
    private static ServiceProvider? serviceProvider;

    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();

        // Configurar servicios como antes
        DependencyInjection.ConfigureServices(services);

        // Construir el contenedor
        serviceProvider = services.BuildServiceProvider();

        // Inicializar WinForms
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Lanzar el formulario principal
        var mainForm = serviceProvider.GetRequiredService<ViewForm>();
        Application.Run(mainForm);
    }
}
