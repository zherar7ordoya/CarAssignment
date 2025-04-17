using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Presentation.Composition;

public static class AppServices
{
    public static IServiceProvider Provider { get; set; } = default!;
    public static T GetService<T>() where T : notnull => Provider.GetRequiredService<T>();
}
