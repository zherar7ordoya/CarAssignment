using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence.SQLite.Mappers;
using Integrador.Infrastructure.Persistence.SQLite;
using Integrador.Infrastructure.Persistence.XML;
using Integrador.Presentation.Factories;
using Integrador.Presentation.Presenters;
using Integrador.Infrastructure.Persistence.SQLite.Records;

namespace Integrador.Presentation.Composition;

public class DependencyInjection
{
    public static SimpleServiceProvider Configure()
    {
        var provider = new SimpleServiceProvider();
        //
        // Xml persistence
        //
        provider.Register(typeof(IXmlDataSource<>), typeof(XmlDataSource<>));
        provider.Register(typeof(IRepository<>), typeof(XmlRepository<>));
        provider.Register<IRepository<Person>, XmlRepository<Person>>();
        provider.Register<IRepository<Car>, XmlRepository<Car>>();
        //
        // Sqlite persistence
        //
        provider.Register<IMapper<Person, PersonRecord>, PersonMapper>();
        provider.Register<IMapper<Car, CarRecord>, CarMapper>();
        provider.Register<ISQLiteDataSource<Person>, SQLiteDataSource<Person>>();
        provider.Register<ISQLiteDataSource<Car>, SQLiteDataSource<Car>>();
        provider.Register<IRepository<Person>, SQLiteRepository<Person>>();
        provider.Register<IRepository<Car>, SQLiteRepository<Car>>();
        //
        // Exception handling
        //
        provider.Register<IExceptionHandler, ExceptionHandler>();
        provider.Register<ILogger, Logger>();
        provider.Register<IMessenger, Messenger>();
        //
        // Application
        //
        provider.Register<IAssignmentService, AssignmentService>();
        provider.Register<ICarService, CarService>();
        provider.Register<IPersonService, PersonService>();
        //
        // View
        //
        provider.Register<ICarFactory, CarFactory>();
        provider.Register<IPersonFactory, PersonFactory>();
        provider.Register<IViewPresenter, ViewPresenter>();
        provider.Register<ViewForm, ViewForm>();

        return provider;
    }
}
