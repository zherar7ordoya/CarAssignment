using CarAssignment.Presentation.Composition;

using Integrador;

using SQLitePCL;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        AppServiceProvider.Provider = DependencyInjection.Configure();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Batteries.Init();

        Application.Run(AppServiceProvider.GetService<MainForm>());
    }
}
