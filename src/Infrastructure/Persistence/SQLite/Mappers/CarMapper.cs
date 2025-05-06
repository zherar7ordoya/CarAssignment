using CarAssignment.Domain.Entities;
using CarAssignment.Infrastructure.Interfaces.Persistence;
using CarAssignment.Infrastructure.Persistence.SQLite.Records;

namespace CarAssignment.Infrastructure.Persistence.SQLite.Mappers;

public class CarMapper : IMapper<Car, CarRecord>
{
    public CarRecord ToStorage(Car entity) => new()
    {
        Id = entity.Id,
        LicensePlate = entity.LicensePlate,
        Brand = entity.Brand,
        Model = entity.Model,
        Year = entity.Year,
        Price = entity.Price,
        PersonId = entity.PersonId
    };

    public Car ToDomain(CarRecord storage) => new()
    {
        Id = storage.Id,
        LicensePlate = storage.LicensePlate,
        Brand = storage.Brand,
        Model = storage.Model,
        Year = storage.Year,
        Price = storage.Price,
        PersonId = storage.PersonId ?? 0
    };
}
