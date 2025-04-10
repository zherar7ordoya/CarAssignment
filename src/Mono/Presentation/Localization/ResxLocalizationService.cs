using System.Globalization;
using System.Resources;

namespace Integrador.Presentation.Localization;

public class ResxLocalizationService : ILocalizationService
{
    private readonly ResourceManager _resourceManager;
    private CultureInfo _culture;

    public ResxLocalizationService()
    {
        // Notá que usamos el namespace + Resources (sin .resx)
        _resourceManager = new ResourceManager("Integrador.Presentation.Localization.Resources", typeof(ResxLocalizationService).Assembly);
        _culture = CultureInfo.CurrentUICulture;
    }

    public string this[string key] => _resourceManager.GetString(key, _culture) ?? $"[{key}]";

    public void SetCulture(string cultureCode)
    {
        _culture = new CultureInfo(cultureCode);
        CultureInfo.CurrentUICulture = _culture;
    }
}
