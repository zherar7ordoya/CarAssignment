using Integrador.Domain.Entities;
using Integrador.Infrastructure.Interfaces.Persistence;
using Integrador.Infrastructure.Persistence.SQLite.Records;

namespace Integrador.Infrastructure.Persistence.SQLite.Mappers;

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
