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

    public Person(int id,
                  string dni,
                  string nombre,
                  string apellido,
                  List<int> autos)
    {
        Id = id;
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        Autos = autos ?? []; // Evitar null en la lista de autos
    }

    // Public setters required for serialization.
    // Default values required by empty constructor.
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public List<int> Autos { get; set; } = [];

    public bool HasCars() => Autos.Count > 0;

    public bool OwnsCar(int id)
    {
        var owned = Autos.FirstOrDefault(x => x == id);
        return owned != 0;
    }

    //public void AssignCar(Car car)
    //{
    //    Autos.Add(car.Id);
    //}

    public void RemoveCar(int id)
    {
        var removable = Autos.FirstOrDefault(x => x == id);

        if (removable == 0)
        {
            throw new Exception("El auto no pertenece a la persona.");
        }
        else
        {
            Autos.Remove(removable);
        }
    }

    public List<int> GetCarsList() => Autos;
    public string GetNameSurname() => $"{Apellido}, {Nombre}";
    public string GetIdentityNumber() => DNI;

    public override string ToString() => $"{nameof(Person)} Id {Id}: {DNI} - {Nombre} {Apellido}";
}
