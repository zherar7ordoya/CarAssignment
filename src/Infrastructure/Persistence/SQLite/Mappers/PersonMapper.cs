using CarAssignment.Domain.Entities;
using CarAssignment.Infrastructure.Interfaces.Persistence;
using CarAssignment.Infrastructure.Persistence.SQLite.Records;

namespace CarAssignment.Infrastructure.Persistence.SQLite.Mappers;

public class PersonMapper : IMapper<Person, PersonRecord>
{
    public PersonRecord ToStorage(Person entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        IdentityNumber = entity.IdentityNumber,
        CarIds = string.Join(",", entity.CarIds)
    };

    public Person ToDomain(PersonRecord storage) => new()
    {
        Id = storage.Id,
        FirstName = storage.FirstName,
        LastName = storage.LastName,
        IdentityNumber = storage.IdentityNumber,
        CarIds = string.IsNullOrWhiteSpace(storage.CarIds)
        ? []
        : [.. storage.CarIds.Split(',').Select(int.Parse)]
    };
}
