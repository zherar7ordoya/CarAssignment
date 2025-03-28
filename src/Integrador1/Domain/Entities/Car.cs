using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Car : BaseEntity
{
    // Constructor con validación
    public Car(string patente, string marca, string modelo, int año, decimal precio)
    {
        Validate(patente, marca, modelo, año, precio);
        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
    }

    // Propiedades encapsuladas
    public string Patente { get; private set; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public int Año { get; private set; }
    public decimal Precio { get; private set; }

    // Relación con Person (sin exposición de ID)
    private Person? _dueño;
    public Person? Dueño => _dueño;

    // Método para verificar si se puede eliminar
    public void EnsureCanBeDeleted()
    {
        if (_dueño != null)
            throw new DomainException("No se puede eliminar un auto asignado a un dueño.");
    }

    // Método para asignar dueño (ejemplo de lógica de dominio)
    public void AssignOwner(Person person)
    {
        _dueño = person;
    }
}