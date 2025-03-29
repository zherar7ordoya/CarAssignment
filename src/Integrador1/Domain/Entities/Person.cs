using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Person : BaseEntity
{
    // Empty constructor required by serialization.
    public Person() { }
    public Person(string dni,
                  string nombre,
                  string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }
    // Public set for serialization, default values because of empty constructor
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public List<Car> Autos { get; set; } = [];

    // Regla de negocio: No permitir eliminar si tiene autos asociados
    public void EnsureCanBeDeleted()
    {
        if (Autos.Count > 0)
        {
            throw new DomainException("No se puede eliminar una persona con autos asociados.");
        }
    }

    // Validación de negocio para actualización
    public void EnsureCanBeUpdated()
    {
        if (Autos.Count > 0)
            throw new DomainException("No se puede actualizar una persona con autos asociados.");
    }

    public void AssignCar(Car car)
    {
        car.EnsureCanBeAssigned(); // Valida antes de asignar
        Autos.Add(car);
        car.AssignTo(this);
    }

    // Método para remover auto (encapsula colección)
    public void RemoveCar(Car car)
    {
        if (!Autos.Contains(car))
        {
            throw new DomainException("El auto no pertenece a esta persona.");
        }

        Autos.Remove(car);
    }
}
