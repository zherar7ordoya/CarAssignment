using Integrador.Application;
using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.Services;
using Integrador.Infrastructure;
using Integrador.Infrastructure.Messaging;
using Integrador.Presentation.Factories;
using Integrador.Presentation.Presenters;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Presentation;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Agregar servicios de la capa Application
        services.AddApplication();

        // Agregar servicios de la capa Infrastructure
        services.AddInfrastructure();

        // Agregar servicios de la capa Presentation
        services.AddSingleton<IMessenger, Messenger>();
        services.AddSingleton<ICarFactory, CarFactory>();
        services.AddSingleton<IPersonFactory, PersonFactory>();
        services.AddScoped<IViewPresenter, ViewPresenter>();
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IAssignmentService, AssignmentService>();

        // --- Formulario Principal ---
        services.AddTransient<ViewForm>();
    }
}
