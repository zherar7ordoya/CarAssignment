using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Presentation.Views;

public interface ILocalizationService
{
    string this[string key] { get; }
    void SetCulture(string cultureCode); // Ej: "en", "es"
}
