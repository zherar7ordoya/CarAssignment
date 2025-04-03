using Integrador.Application;
using Integrador.Application.Interfaces;
using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure;
using Integrador.Infrastructure.Persistence;
using Integrador.Presentation.Presenters;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Presentation;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // --- Configuración de Capas ---

        // Agregar servicios de la capa Application
        services.AddApplication();

        // Agregar servicios de la capa Infrastructure
        services.AddInfrastructure();

        // --- Repositorios ---
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        services.AddScoped<IGenericRepository<Car>, GenericRepository<Car>>();

        // --- Managers (Lógica de Negocio) ---
        services.AddScoped<IPersonManager, PersonService>();
        services.AddScoped<ICarManager, CarService>();
        services.AddScoped<IAssignmentManager, AssignmentService>();

        // --- Presenters (Interacción con la UI) ---
        services.AddScoped<IViewPresenter, ViewPresenter>();

        // --- Formulario Principal ---
        // Se usa AddTransient porque cada vez que se inyecte ViewForm, se creará una nueva instancia.
        services.AddTransient<ViewForm>();
    }
}
