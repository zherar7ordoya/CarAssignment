using Integrador;
using Integrador.Presentation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static class Program
{
    // Se inicializa en Main y se mantiene de solo lectura para evitar modificaciones accidentales.
    private static readonly IHost host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Se configura la inyección de dependencias llamando a Startup.
            Startup.ConfigureServices(services);
        })
        .Build();

    [STAThread]
    static void Main()
    {
        // Habilitar estilos visuales de Windows Forms para una mejor apariencia.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Obtener e iniciar el formulario principal desde el contenedor de dependencias.
        Application.Run(host.Services.GetRequiredService<ViewForm>());
    }
}
