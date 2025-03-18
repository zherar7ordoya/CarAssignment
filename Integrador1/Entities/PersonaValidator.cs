using System.Text.RegularExpressions;

namespace Integrador.Entities;

public static partial class PersonaValidator
{
    [System.Text.RegularExpressions.GeneratedRegex(@"^\d{7,8}$")]
    private static partial Regex DniRegex();

    public static void Validar(Persona persona)
    {
        if (string.IsNullOrEmpty(persona.DNI) || !DniRegex().IsMatch(persona.DNI))
        {
            throw new ArgumentException("Formato de DNI inválido.");
        }

        if (string.IsNullOrEmpty(persona.Nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.");
        }

        if (string.IsNullOrEmpty(persona.Apellido))
        {
            throw new ArgumentException("El apellido no puede estar vacío.");
        }
    }
}
