using System.Configuration;

namespace Integrador.Infrastructure.Configuration;

public static class AppConfigReader
{
    public static string? GetSetting(string key)
    {
        return ConfigurationManager.AppSettings[key];
    }
}
