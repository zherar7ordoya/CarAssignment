namespace Integrador.Presentation.Composition;

public static class AppServices
{
    public static ServiceProvider Provider { get; set; } = default!;
    public static T Get<T>() where T : notnull => Provider.Resolve<T>();
}
