using Integrador.Application.Interfaces;
using Integrador.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IDataSource<>), typeof(DataSource<>));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
