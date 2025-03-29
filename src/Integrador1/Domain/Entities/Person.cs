using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Person(string dni,
                    string nombre,
                    string apellido) : BaseEntity
{

    // Propiedades encapsuladas
    public string DNI { get; private set; } = dni;
    public string Nombre { get; private set; } = nombre;
    public string Apellido { get; private set; } = apellido;
    public IReadOnlyCollection<Car> Autos => _autos;
    private readonly List<Car> _autos = [];

    // Regla de negocio: No permitir eliminar si tiene autos asociados
    public void EnsureCanBeDeleted()
    {
        if (_autos.Count > 0)
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
        _autos.Add(car);
        car.AssignTo(this);
    }

    // Método para remover auto (encapsula colección)
    public void RemoveCar(Car car)
    {
        if (!_autos.Contains(car))
        {
            throw new DomainException("El auto no pertenece a esta persona.");
        }

        _autos.Remove(car);
    }
}
