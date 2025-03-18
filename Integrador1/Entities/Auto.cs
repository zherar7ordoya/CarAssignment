using Integrador1.Abstract;

using System.Xml.Serialization;

namespace Integrador1.Entities;

public class Auto : Entity
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
    ~Auto() => AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
