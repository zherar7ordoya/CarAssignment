namespace Integrador.Domain.Entities;

public class Person : EntityBase
{
    // Empty constructor required by serialization.
    public Person() { }
    public Person(string identityNumber,
                  string firstName,
                  string lastName)
    {
        IdentityNumber = identityNumber;
        FirstName = firstName;
        LastName = lastName;
    }

    public Person(int id,
                  string identityNumber,
                  string firstName,
                  string lastName,
                  List<int> carIds)
    {
        Id = id;
        IdentityNumber = identityNumber;
        FirstName = firstName;
        LastName = lastName;
        CarIds = carIds ?? []; // Avoid null list
    }

    // Public setters required for serialization.
    // Default values required by empty constructor.
    public string IdentityNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<int> CarIds { get; set; } = [];

    public bool HasCars() => CarIds.Count > 0;

    public bool OwnsCar(int id) => CarIds.Contains(id);

    public void AssignCar(int id)
    {
        if (CarIds.Contains(id)) throw new Exception("Car already assigned to person.");
        CarIds.Add(id);
    }

    public void RemoveCar(int id)
    {
        if (!CarIds.Contains(id)) throw new Exception("Car is not assigned to this person.");
        CarIds.Remove(id);
    }

    public string GetNameSurname() => $"{LastName}, {FirstName}";
    public string GetIdentityNumber() => IdentityNumber;

    public override string ToString() => $"{nameof(Person)} Id {Id}: {IdentityNumber} - {FirstName} {LastName}";
}
