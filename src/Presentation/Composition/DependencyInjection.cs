using Microsoft.Extensions.DependencyInjection;
using Integrador.Presentation.Views;
using Integrador.Presentation.Views.Forms;
using CarAssignment.Infrastructure.Interfaces.Persistence;
using CarAssignment.Infrastructure.Logging.JSON;
using CarAssignment.Application.Security.Services;
using CarAssignment.Infrastructure.Logging.Shared;
using CarAssignment.Infrastructure.Interfaces;
using CarAssignment.Application.Security.Contracts;
using CarAssignment.Infrastructure.Configuration;
using Integrador;
using CarAssignment.Infrastructure.Persistence.JSON;
using CarAssignment.Presentation.Factories;
using CarAssignment.Domain.Entities;
using CarAssignment.Infrastructure.Persistence.SQLite.Repository;
using CarAssignment.Infrastructure.Persistence.SQLite.Context;
using CarAssignment.Infrastructure.Persistence.LiteDB.Context;
using CarAssignment.Application.Services;
using CarAssignment.Infrastructure.Persistence.SQLite.Mappers;
using CarAssignment.Application.Interfaces.Utilities;
using CarAssignment.Infrastructure.Persistence.SQLite.Records;
using CarAssignment.Application.Interfaces.Presentation;
using CarAssignment.Application.Interfaces.Services;
using CarAssignment.Application.Interfaces.Exceptions;
using CarAssignment.Application.Authentication;
using CarAssignment.Infrastructure.Exceptions;
using CarAssignment.Infrastructure.Persistence.XML.Context;
using CarAssignment.Presentation.Presenters;
using CarAssignment.Infrastructure.Messaging;
using CarAssignment.Infrastructure.Persistence.XML.Repository;
using CarAssignment.Infrastructure.Persistence.LiteDB.Repository;

namespace CarAssignment.Presentation.Composition;

public static class DependencyInjection
{
    public static IServiceProvider Configure()
    {
        var services = new ServiceCollection();
        var tech = SystemSettings.GetPersistenceTechnology(key => AppConfigReader.GetSetting(key)!);

        switch (tech)
        {
            case PersistenceProviderType.XML:
                RegisterXmlPersistence(services);
                break;
            case PersistenceProviderType.SQLite:
                RegisterSQLitePersistence(services);
                break;
            case PersistenceProviderType.LiteDB:
                RegisterLiteDbPersistence(services);
                break;
        }

        RegisterCoreServices(services);

        return services.BuildServiceProvider();
    }

    private static void RegisterXmlPersistence(IServiceCollection services)
    {
        services.AddTransient(typeof(IXmlContext<>), typeof(XmlContext<>));
        services.AddTransient(typeof(IRepository<>), typeof(XmlRepository<>));
        services.AddTransient<IRepository<Person>, XmlRepository<Person>>();
        services.AddTransient<IRepository<Car>, XmlRepository<Car>>();
    }

    private static void RegisterSQLitePersistence(IServiceCollection services)
    {
        services.AddTransient(typeof(ISQLiteContext<>), typeof(SQLiteContext<>));
        services.AddTransient<IRepository<Person>, SQLiteRepository<Person, PersonRecord>>();
        services.AddTransient<IRepository<Car>, SQLiteRepository<Car, CarRecord>>();
        services.AddTransient<IMapper<Person, PersonRecord>, PersonMapper>();
        services.AddTransient<IMapper<Car, CarRecord>, CarMapper>();
    }

    private static void RegisterLiteDbPersistence(IServiceCollection services)
    {
        services.AddTransient(typeof(ILiteDbContext<>), typeof(LiteDbContext<>));
        services.AddTransient(typeof(IRepository<>), typeof(LiteDbRepository<>));
    }

    private static void RegisterCoreServices(IServiceCollection services)
    {

        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IAuthorizationService, AuthorizationService>();

        services.AddSingleton<IUserRepository, JsonUserRepository>();
        services.AddSingleton<IRoleRepository, JsonRoleRepository>();

        services.AddSingleton<IUserManagerService, UserManagerService>();
        services.AddSingleton<IRoleManagerService, RoleManagerService>();

        services.AddSingleton<IExceptionHandler, ExceptionHandler>();
        services.AddSingleton<IMessenger, Messenger>();

        services.AddSingleton<ILogWriter, JsonLogWriter>();
        services.AddSingleton<ILogReader, JsonLogReader>();
        services.AddSingleton<ILogger, Logger>();

        services.AddTransient<LogViewerForm>();
        services.AddTransient<UserManagementForm>();
        services.AddTransient<RoleManagementForm>();

        services.AddTransient<IAssignmentService, AssignmentService>();
        services.AddTransient<ICarService, CarService>();
        services.AddTransient<IPersonService, PersonService>();

        services.AddTransient<ICarFactory, CarDTOFactory>();
        services.AddTransient<IPersonFactory, PersonDTOFactory>();
        services.AddTransient<IViewPresenter, ViewPresenter>();

        services.AddTransient<MainForm, MainForm>();
    }
}
