using Integrador.Core;

using System.Text.RegularExpressions;

namespace Integrador.Entities;

public static partial class AutoValidator
{
    [System.Text.RegularExpressions.GeneratedRegex(@"^[A-Z]{2}\d{3}[A-Z]{2}$|^[A-Z]{3}\d{3}$")]
    private static partial Regex PatenteRegex();

    public static void Validar(Auto auto)
    {
        if (string.IsNullOrEmpty(auto.Patente) || !PatenteRegex().IsMatch(auto.Patente))
        {
            throw new ArgumentException("Formato de patente inválido.");
        }

        if (string.IsNullOrEmpty(auto.Marca))
        {
            throw new ArgumentException("La marca no puede estar vacía.");
        }

        if (string.IsNullOrEmpty(auto.Modelo))
        {
            throw new ArgumentException("El modelo no puede estar vacío.");
        }

        if (auto.Año < 1900 || auto.Año > DateTime.Now.Year)
        {
            throw new ArgumentException("Año inválido.");
        }

        if (auto.Precio <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor a 0.");
        }
    }
}
