using Integrador.Adapters.Persistence;

namespace Integrador.Entities;

public class Persona : BaseEntity, IDisposable
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
    public void Dispose()
    {
        PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
        GC.SuppressFinalize(this);
    }

    //~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
