using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using FluentValidation;
using Integrador.Infrastructure.Persistence;
using Integrador;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Messaging;
using Serilog;
using Integrador.Application.Interfaces;
using Integrador.Presentation.Exceptions;
using Integrador.Application.Factories;

static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Configuración inicial de Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.WithThreadId() // Captura el ID del hilo
            .Enrich.WithMachineName() // Nombre de la máquina
            .Enrich.WithEnvironmentUserName() // Usuario de la máquina
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                path: "logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] ({ThreadId}) {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        // 2. Configuración del Host
        var host = Host.CreateDefaultBuilder()
            .UseSerilog() // Integra Serilog con el host
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
                
                // Reemplaza tu logger actual con Serilog
                services.AddSingleton<ILogger>(Log.Logger); // Usa directamente el logger de Serilog
                
                services.AddSingleton<IMessenger, Messenger>();
                services.AddSingleton<IExceptionHandler, ExceptionHandler>();
                services.AddSingleton<ICarFactory, CarFactory>();
                services.AddSingleton<IPersonFactory, PersonFactory>();

                // Repositorios genéricos
                services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                // UI
                services.AddTransient<ViewForm>();
            })
            .Build();

        // 3. Manejo global de excepciones
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (sender, e) => HandleException(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => HandleException(e.ExceptionObject as Exception);

        // 4. Ejecución de la aplicación
        Application.Run(host.Services.GetRequiredService<ViewForm>());
    }

    private static void HandleException(Exception ex)
    {
        if (ex == null) return;

        // Usa Serilog para registrar el error
        Log.Fatal(ex, "Excepción no manejada: {ErrorMessage}", ex.Message);

        // Muestra un mensaje al usuario
        MessageBox.Show("Ocurrió un error inesperado. Consulte el log para más detalles.",
                        "Error Crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
    }
}
