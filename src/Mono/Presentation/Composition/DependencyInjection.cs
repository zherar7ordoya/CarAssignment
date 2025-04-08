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
using Integrador.Infrastructure.Configuration;

namespace Integrador.Presentation.Composition;

public class DependencyInjection
{
    public static SimpleServiceProvider Configure()
    {
        var provider = new SimpleServiceProvider();
        var tech = SystemSettings.GetPersistenceTechnology();

        switch (tech)
        {
            case PersistenceProviderType.XML:
                RegisterXmlPersistence(provider);
                break;
            case PersistenceProviderType.SQLite:
                RegisterSQLitePersistence(provider);
                break;
            case PersistenceProviderType.LiteDB:
                RegisterLiteDbPersistence(provider);
                break;
            default:
                throw new InvalidOperationException("Unknown persistence technology.");
        }

        RegisterCoreServices(provider);
        return provider;
    }

    /* ////////////////////////////////////////////////////////////////////// */

    private static void RegisterXmlPersistence(SimpleServiceProvider provider)
    {
        provider.Register(typeof(IXmlContext<>), typeof(XmlContext<>));
        provider.Register(typeof(IRepository<>), typeof(XmlRepository<>));
        provider.Register<IRepository<Person>, XmlRepository<Person>>();
        provider.Register<IRepository<Car>, XmlRepository<Car>>();
    }

    private static void RegisterSQLitePersistence(SimpleServiceProvider provider)
    {
        provider.Register(typeof(ISQLiteContext<>), typeof(SQLiteContext<>));
        provider.Register<IRepository<Person>, SQLiteRepository<Person, PersonRecord>>();
        provider.Register<IRepository<Car>, SQLiteRepository<Car, CarRecord>>();
        provider.Register<IMapper<Person, PersonRecord>, PersonMapper>();
        provider.Register<IMapper<Car, CarRecord>, CarMapper>();
    }

    private static void RegisterLiteDbPersistence(SimpleServiceProvider provider)
    {
        provider.Register(typeof(ILiteDbContext<>), typeof(LiteDbContext<>));
        provider.Register(typeof(IRepository<>), typeof(LiteDbRepository<>));
    }

    private static void RegisterCoreServices(SimpleServiceProvider provider)
    {
        provider.Register<IExceptionHandler, ExceptionHandler>();
        provider.Register<ILogger, Logger>();
        provider.Register<IMessenger, Messenger>();

        provider.Register<IAssignmentService, AssignmentService>();
        provider.Register<ICarService, CarService>();
        provider.Register<IPersonService, PersonService>();

        provider.Register<ICarFactory, CarFactory>();
        provider.Register<IPersonFactory, PersonFactory>();
        provider.Register<IViewPresenter, ViewPresenter>();
        provider.Register<MainForm, MainForm>();
    }
}
