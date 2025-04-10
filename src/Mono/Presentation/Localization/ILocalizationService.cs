namespace Integrador.Presentation.Localization;

public interface ILocalizationService
{
    string this[string key] { get; }
    void SetCulture(string cultureCode); // Ej: "en", "es"
}
