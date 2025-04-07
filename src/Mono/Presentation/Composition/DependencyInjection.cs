using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Persistence.XML;
using Integrador.Presentation.Factories;
using Integrador.Presentation.Presenters;

namespace Integrador.Presentation.Composition;

public class DependencyInjection
{
    public static SimpleServiceProvider Configure()
    {
        var provider = new SimpleServiceProvider();

        provider.Register<IRepository<Person>, XmlRepository<Person>>();
        provider.Register<IRepository<Car>, XmlRepository<Car>>();
        provider.Register<ILogger, Logger>();
        provider.Register(typeof(IXmlDataSource<>), typeof(XmlDataSource<>));
        provider.Register(typeof(IRepository<>), typeof(XmlRepository<>));
        provider.Register<IMessenger, Messenger>();
        provider.Register<ICarFactory, CarFactory>();
        provider.Register<IPersonFactory, PersonFactory>();
        provider.Register<IViewPresenter, ViewPresenter>();
        provider.Register<IExceptionHandler, ExceptionHandler>();
        provider.Register<IPersonService, PersonService>();
        provider.Register<ICarService, CarService>();
        provider.Register<IAssignmentService, AssignmentService>();
        provider.Register<ViewForm, ViewForm>();

        return provider;
    }
}
