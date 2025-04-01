using Integrador.Application.Interfaces;

namespace Integrador.Domain.Entities;

public class Car : BaseEntity, ICar
{
    // Empty constructor required by serialization
    public Car() { }

    public Car(string patente,
               string marca,
               string modelo,
               int año,
               decimal precio)
    {
        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
    }

    // Public setters required for serialization.
    // Default values required by empty constructor.
    public string Patente { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Año { get; set; } = 0;
    public decimal Precio { get; set; } = 0;

    // Relación manejada por ID (no referencia directa a Person)
    // para evitar referencias circulares en la serialización.
    public int DueñoId { get; set; } = 0;

    public bool HasOwner() => DueñoId > 0;

    public void AssignOwner(int id)
    {
        DueñoId = id;
    }

    public void RemoveOwner()
    {
        DueñoId = 0;
    }
}
