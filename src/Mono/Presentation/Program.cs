using Integrador;
using Integrador.Presentation.Composition;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        AppServices.Provider = DependencyInjection.Configure();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(AppServices.Get<ViewForm>());
    }
}
