using Integrador;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Localization;

using SQLitePCL;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        AppServices.Provider = DependencyInjection.Configure();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Batteries.Init();

        Application.Run(AppServices.Get<MainForm>());
    }
}
