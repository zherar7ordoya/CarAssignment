using System.Configuration;

namespace CarAssignment.Infrastructure.Configuration;

public static class AppConfigReader
{
    public static string? GetSetting(string key)
    {
        return ConfigurationManager.AppSettings[key];
    }
}
