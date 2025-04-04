using Integrador.Application.Interfaces;
using Integrador.Application.Logging;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        services.AddScoped<IGenericRepository<Car>, GenericRepository<Car>>();
        services.AddSingleton<ILogger, Logger>();

        return services;
    }
}
