using Integrador.Application.Exceptions;
using Integrador.Application.Factories;
using Integrador.Application.Interfaces;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddSingleton<ICarFactory, CarFactory>();
        services.AddSingleton<IPersonFactory, PersonFactory>();
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();

        return services;
    }
}
