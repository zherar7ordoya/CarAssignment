using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using FluentValidation;
using Integrador.Application.Behaviors;
using Integrador.Infrastructure.Persistence;
using Integrador.Domain.Interfaces;
using Integrador;

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
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                });

                // Validadores de FluentValidation
                services.AddValidatorsFromAssembly(typeof(Program).Assembly);

                // Repositorios genéricos
                services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                // UI
                services.AddTransient<ViewForm>();
            })
            .Build();

        System.Windows.Forms.Application.Run(host.Services.GetRequiredService<ViewForm>());
    }
}