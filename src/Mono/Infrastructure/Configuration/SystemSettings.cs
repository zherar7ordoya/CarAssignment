using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Configuration;

public static class SystemSettings
{
    public static PersistenceProviderType GetPersistenceTechnology()
    {
        var value = ConfigurationManager.AppSettings["PersistenceTechnology"];
        return Enum.TryParse(value, out PersistenceProviderType tech)
            ? tech
            : throw new InvalidOperationException("Invalid persistence technology configured.");
    }
}
