using Microsoft.Extensions.DependencyInjection;
using Integrador;

static class Program
{
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        DependencyInjection.ConfigureServices(services);
        var provider = services.BuildServiceProvider();
        AppServices.Provider = provider;

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(provider.GetRequiredService<ViewForm>());
    }
}
