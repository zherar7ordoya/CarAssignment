using Integrador.Presentation.Views;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Presentation;

public class ResxLocalizationService : ILocalizationService
{
    private readonly ResourceManager _resourceManager;
    private CultureInfo _culture;

    public ResxLocalizationService()
    {
        // Notá que usamos el namespace + Resources (sin .resx)
        _resourceManager = new ResourceManager("Integrador.Properties.Resources", typeof(ResxLocalizationService).Assembly);
        _culture = CultureInfo.CurrentUICulture;
    }

    public string this[string key] => _resourceManager.GetString(key, _culture) ?? $"[{key}]";

    public void SetCulture(string cultureCode)
    {
        _culture = new CultureInfo(cultureCode);
        CultureInfo.CurrentUICulture = _culture;
    }
}
