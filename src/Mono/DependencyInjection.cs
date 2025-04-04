using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.Logging;
using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence;
using Integrador.Presentation.Factories;
using Integrador.Presentation.Presenters;

using Microsoft.Extensions.DependencyInjection;

namespace Integrador;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        services.AddScoped<IGenericRepository<Car>, GenericRepository<Car>>();
        services.AddSingleton<ILogger, Logger>();
        services.AddSingleton(typeof(IDataSource<>), typeof(DataSource<>));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddSingleton<IMessenger, Messenger>();
        services.AddSingleton<ICarFactory, CarFactory>();
        services.AddSingleton<IPersonFactory, PersonFactory>();
        services.AddScoped<IViewPresenter, ViewPresenter>();
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddTransient<ViewForm>();
    }
}
