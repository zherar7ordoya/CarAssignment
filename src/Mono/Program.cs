using Integrador;
using Integrador.Presentation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static class Program
{
    private static IHost host = null!; // Se inicializa en Main

    [STAThread]
    static void Main()
    {
        // Crear el Host con DI
        host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var startup = new Startup();
                Startup.ConfigureServices(services);
            })
            .Build();

        // Ejecutar la aplicación
        Application.Run(host.Services.GetRequiredService<ViewForm>());
    }

    
}
