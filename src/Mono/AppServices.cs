using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador;

public static class AppServices
{
    public static IServiceProvider Provider { get; set; } = default!;
    public static T Get<T>() where T : notnull => Provider.GetRequiredService<T>();
}
