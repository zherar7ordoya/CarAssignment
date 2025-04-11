using Integrador.Application.Exceptions;
using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence.SQLite.Mappers;
using Integrador.Presentation.Factories;
using Integrador.Presentation.Presenters;
using Integrador.Infrastructure.Persistence.SQLite.Records;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Application.Interfaces.Services;
using Integrador.Application.Interfaces.Utilities;
using Integrador.Infrastructure.Persistence.LiteDB.Context;
using Integrador.Infrastructure.Persistence.LiteDB.Repository;
using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Presentation;
using Integrador.Infrastructure.Persistence.SQLite.Context;
using Integrador.Infrastructure.Persistence.XML.Context;
using Integrador.Infrastructure.Persistence.XML.Repository;
using Integrador.Infrastructure.Persistence.SQLite.Repository;
using Integrador.Presentation.Localization;
using Integrador.Application.Configuration;
using Integrador.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Integrador.Presentation.Views;

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
        services.AddSingleton<IExceptionHandler, ExceptionHandler>();
        services.AddSingleton<IMessenger, Messenger>();

        services.AddSingleton<ILogWriter, LiteDbLogWriter>();
        services.AddSingleton<ILogReader, LiteDbLogReader>();
        services.AddSingleton<ILogger, StructuredLogger>();

        services.AddTransient<LogViewerForm>();


        services.AddTransient<IAssignmentService, AssignmentService>();
        services.AddTransient<ICarService, CarService>();
        services.AddTransient<IPersonService, PersonService>();

        services.AddTransient<ICarFactory, CarFactory>();
        services.AddTransient<IPersonFactory, PersonFactory>();
        services.AddTransient<IViewPresenter, ViewPresenter>();

        services.AddSingleton<ILocalizationService>(_ =>
        {
            var culture = AppConfigReader.GetSetting("DefaultCulture") ?? "es";
            var localization = new ResxLocalizationService();
            localization.SetCulture(culture);
            return localization;
        });

        services.AddTransient<MainForm, MainForm>();
    }
}
