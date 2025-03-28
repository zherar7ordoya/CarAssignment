namespace Integrador.Domain.Entities;

public class Person : BaseEntity, IDisposable
{
    public Person() { }
    public Person(string dni, string nombre, string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }
    //--------------------------------------------------------------------------
    public string? DNI { get; set; } = string.Empty;
    public string? Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; } = string.Empty;
    public List<Car> Autos { get; set; } = [];
    //--------------------------------------------------------------------------
    public static event Action<string>? PersonaEliminada;
    public void Dispose()
    {
        PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
        GC.SuppressFinalize(this);
    }

    //~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
