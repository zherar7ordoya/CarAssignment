using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Car(string patente,
                 string marca,
                 string modelo,
                 int año,
                 decimal precio) : BaseEntity
{

    // Propiedades encapsuladas
    public string Patente { get; private set; } = patente;
    public string Marca { get; private set; } = marca;
    public string Modelo { get; private set; } = modelo;
    public int Año { get; private set; } = año;
    public decimal Precio { get; private set; } = precio;

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

    // Método para actualización segura
    public void Update(string marca, string modelo, decimal precio)
    {
        // Validar datos antes de actualizar
        if (string.IsNullOrEmpty(marca))
        {
            throw new DomainException("Marca no puede estar vacía.");
        }

        Marca = marca;
        Modelo = modelo;
        Precio = precio;
    }

    // Validación de negocio para actualización
    public void EnsureCanBeUpdated()
    {
        // Ejemplo: Verificar si el auto está asignado a alguien
        if (Dueño != null)
        {
            throw new DomainException("No se puede actualizar un auto asignado a un dueño.");
        }
    }

    // Método de dominio para asignación
    public void EnsureCanBeAssigned()
    {
        if (Dueño != null)
            throw new DomainException("El auto ya tiene un dueño.");
    }

    public void AssignTo(Person person)
    {
        _dueño = person;
    }

    // Método para desasignar dueño
    public void DissociateOwner()
    {
        _dueño = null;
    }
}
