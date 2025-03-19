using Integrador.Abstract;

namespace Integrador.Entities;

public class Persona : Entity
{
    public Persona() { }
    public Persona(string dni, string nombre, string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }

    //--------------------------------------------------------------------------

    public string? DNI { get; set; } = string.Empty;
    public string? Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; } = string.Empty;
    public List<Auto> Autos { get; set; } = [];
   
    //--------------------------------------------------------------------------

    public static event Action<string>? PersonaEliminada;
    ~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
