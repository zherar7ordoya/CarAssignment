namespace Integrador.Infrastructure.Configuration;

public static class SystemSettings
{
    public static PersistenceProviderType GetPersistenceTechnology(Func<string, string> settingReader)
    {
        var value = settingReader("PersistenceTechnology");

        return Enum.TryParse(value, out PersistenceProviderType tech)
            ? tech
            : throw new InvalidOperationException("Invalid persistence technology configured.");
    }
}
