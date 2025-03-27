using Integrador.Adapters.Persistence;

using System.Xml.Serialization;

namespace Integrador.Entities;

public class Auto : BaseEntity, IDisposable
{
    public Auto() { }
    public Auto(string patente, string marca, string modelo, int año, decimal precio)
    {
        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
    }
    //--------------------------------------------------------------------------
    public string? Patente { get; set; } = string.Empty;
    public string? Marca { get; set; } = string.Empty;
    public string? Modelo { get; set; } = string.Empty;
    public int Año { get; set; } = DateTime.Now.Year;
    public decimal Precio { get; set; } = 0.0m;

    // ¿Por qué esto? Ambas clases se referencian entre sí, por lo que,
    // al serializar, se produciría un ciclo infinito.
    public int DueñoId { get; set; }

    [XmlIgnore]
    public Persona? Dueño
    {
        get => _dueño;
        set
        {
            _dueño = value;
            DueñoId = value?.Id ?? 0;
        }
    }
    private Persona? _dueño;
    //--------------------------------------------------------------------------
    public static event Action<string>? AutoEliminado;
    public void Dispose()
    {
        AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
        GC.SuppressFinalize(this);
    }

    //~Auto() => AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
