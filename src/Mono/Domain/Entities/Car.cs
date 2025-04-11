namespace Integrador.Domain.Entities;

public class Car : EntityBase
{
    // Empty constructor required by serialization
    public Car() { }

    public Car(string licensePlate,
               string brand,
               string model,
               int year,
               decimal price)
    {
        LicensePlate = licensePlate;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    // Public setters required for serialization.
    // Default values required by empty constructor.
    public string LicensePlate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public decimal Price { get; set; } = 0;

    // Relación manejada por ID (no referencia directa a Person)
    // para evitar referencias circulares en la serialización.
    public int PersonId { get; set; } = 0;

    public bool HasOwner() => PersonId > 0;

    public void AssignOwner(int id)
    {
        PersonId = id;
    }

    public void RemoveOwner()
    {
        PersonId = 0;
    }

    public override string ToString() => $"{nameof(Car)} Id {Id}: {LicensePlate} - {Brand} {Model}";
}
