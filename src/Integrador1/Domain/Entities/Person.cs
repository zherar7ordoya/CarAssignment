using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Person : BaseEntity
{
    public Person() { }
    public Person(string dni,
                  string nombre,
                  string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }
    // Propiedades encapsuladas
    public string DNI { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
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
