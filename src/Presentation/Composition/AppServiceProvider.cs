using Microsoft.Extensions.DependencyInjection;

namespace CarAssignment.Presentation.Composition;

public static class AppServiceProvider
{
    public static IServiceProvider Provider { get; set; } = default!;
    public static T GetService<T>() where T : notnull => Provider.GetRequiredService<T>();
}
