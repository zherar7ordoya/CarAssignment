using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using FluentValidation;
using Integrador.Infrastructure.Persistence;
using Integrador;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Domain.Entities;

static class Program
{
    [STAThread]
    static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // MediatR + Validación global
                services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(Integrador.Application.Behaviors.ValidationBehavior<,>));
                });

                // Validadores de FluentValidation
                services.AddValidatorsFromAssembly(typeof(Program).Assembly);

                // Servicios de infraestructura
                services.AddSingleton(typeof(IDataSource<>), typeof(DataSource<>));
                services.AddSingleton<ILogger, Logger>();
                services.AddSingleton<IMessenger, Messenger>();
                services.AddSingleton<IExceptionHandler, ExceptionHandler>();
                services.AddSingleton<ICarFactory, CarFactory>();
                services.AddSingleton<IPersonFactory, PersonFactory>();

                // Repositorios genéricos
                services.AddSingleton(typeof(Integrador.Domain.Interfaces.IGenericRepository<>), typeof(GenericRepository<>));

                // UI
                services.AddTransient<ViewForm>();
            })
            .Build();

        System.Windows.Forms.Application.Run(host.Services.GetRequiredService<ViewForm>());
    }
}