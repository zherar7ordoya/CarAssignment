using Integrador;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Views;

using SQLitePCL;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        AppServices.Provider = DependencyInjection.Configure();

        var localizationService = AppServices.Get<ILocalizationService>();
        localizationService.SetCulture("es"); // o "en", etc.

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Batteries.Init();

        Application.Run(AppServices.Get<MainForm>());
    }
}
