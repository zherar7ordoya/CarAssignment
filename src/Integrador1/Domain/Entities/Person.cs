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

    public bool EnsureCanBeDeleted() => Autos.Count == 0;

    public bool EnsureCarCanBeRemoved(Car car) => Autos.Contains(car);

    public void AssignCar(Car car)
    {
        if (Autos.Contains(car)) return;
        Autos.Add(car);
        car.AssignOwner(this);
    }

    public void RemoveCar(Car car)
    {
        if (!Autos.Contains(car)) return;
        Autos.Remove(car);
        car.RemoveOwner();
    }
}
