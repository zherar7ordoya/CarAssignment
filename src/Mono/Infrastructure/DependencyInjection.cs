using Integrador.Application.Interfaces;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddLogging(); // Agregar configuración de Serilog aquí

        services.AddSingleton(typeof(IDataSource<>), typeof(DataSource<>));
        services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddSingleton<IMessenger, Messenger>();

        return services;
    }
}
