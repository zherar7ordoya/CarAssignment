using Integrador.Application;
using Integrador.Infrastructure;

using Microsoft.Extensions.DependencyInjection;



namespace Integrador.Presentation;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Servicios de capa Application
        services.AddApplication();

        // Servicios de capa Infrastructure
        services.AddInfrastructure();

        // Servicio de capa Presentation
        services.AddTransient<ViewForm>();
    }
}
