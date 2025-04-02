using Integrador.Application.Interfaces;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // --- Configuración de Logging ---
        services.AddLogging();

        // --- Persistencia de Datos ---
        services.AddSingleton(typeof(IDataSource<>), typeof(DataSource<>));

        // Repositorios deben ser Scoped para evitar problemas con la concurrencia del contexto.
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // --- Mensajería / Comunicación ---
        services.AddSingleton<IMessenger, Messenger>();

        return services;
    }
}
