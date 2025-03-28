using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Integrador.Application.Behaviors;
using Integrador.Application.Validators;
using Integrador.Infrastructure.Persistence;
using Integrador.Domain.Interfaces;
using System.Windows.Forms;
using Integrador.Domain.Entities;
using Integrador;

static class Program
{
    [STAThread]
    static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                });

                // Registrar validadores de FluentValidation
                services.AddValidatorsFromAssembly(typeof(Program).Assembly);

                services.AddSingleton<IGenericRepository<Car>, GenericRepository<Car>>();
                services.AddSingleton<IGenericRepository<Person>, GenericRepository<Person>>();

                services.AddTransient<ViewForm>();
            })
            .Build();

        System.Windows.Forms.Application.Run(host.Services.GetRequiredService<ViewForm>());
    }
}