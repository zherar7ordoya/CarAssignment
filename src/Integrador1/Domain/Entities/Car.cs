using Integrador.Domain.Exceptions;

using System.Xml.Serialization;

namespace Integrador.Domain.Entities;

public class Car : BaseEntity
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

    // Public set for serialization, default values because of empty constructor
    public string Patente { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Año { get; set; } = 0;
    public decimal Precio { get; set; } = 0;
    public int DueñoId { get; set; } = 0;
    [XmlIgnore]
    public Person? Dueño { get; set; } = null;


    public bool EnsureCanBeAssigned() => DueñoId == 0;

    public bool EnsureCanBeDeleted()
    {
        return Dueño == null;
    }

    public void AssignOwner(Person person)
    {
        DueñoId = person.Id;
        Dueño = person;
    }

    public void RemoveOwner()
    {
        DueñoId = 0;
        Dueño = null;
    }
}
