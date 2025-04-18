using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence.SQLite.Mappers;
using Integrador.Presentation.Presenters;
using Integrador.Infrastructure.Persistence.SQLite.Records;
using Integrador.Application.Interfaces.Services;
using Integrador.Application.Interfaces.Utilities;
using Integrador.Infrastructure.Persistence.LiteDB.Context;
using Integrador.Infrastructure.Persistence.LiteDB.Repository;
using Integrador.Application.Interfaces.Presentation;
using Integrador.Infrastructure.Persistence.SQLite.Context;
using Integrador.Infrastructure.Persistence.XML.Context;
using Integrador.Infrastructure.Persistence.XML.Repository;
using Integrador.Infrastructure.Persistence.SQLite.Repository;
using Integrador.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Integrador.Presentation.Views;
using Integrador.Infrastructure.Logging.Shared;
using Integrador.Application.Interfaces.Exceptions;
using Integrador.Infrastructure.Logging.JSON;
using Integrador.Application.Authentication;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Interfaces.Persistence;

using Integrador.Infrastructure.Exceptions;
using Integrador.Presentation.Views.Forms;
using Integrador.Infrastructure.Persistence.JSON;
using Integrador.Application.Security.Services;
using Integrador.Application.Security.Contracts;
using Integrador.Presentation.Factories;

namespace Integrador.Presentation.Composition;

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
