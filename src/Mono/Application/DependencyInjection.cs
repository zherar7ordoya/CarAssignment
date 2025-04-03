using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Presentation.Factories;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // --- Fábricas ---
        services.AddSingleton<ICarFactory, CarFactory>();
        services.AddSingleton<IPersonFactory, PersonFactory>();

        // --- Manejador de Excepciones ---
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();

        return services;
    }
}
