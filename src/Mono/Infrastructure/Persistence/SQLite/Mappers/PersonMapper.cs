using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence.SQLite.Records;

namespace Integrador.Infrastructure.Persistence.SQLite.Mappers;

public class PersonMapper : IMapper<Person, PersonRecord>
{
    public PersonRecord ToStorage(Person entity) => new()
    {
        Id = entity.Id,
        Nombre = entity.Nombre,
        Apellido = entity.Apellido,
        DNI = entity.DNI,
        Autos = string.Join(",", entity.Autos)
    };

    public Person ToDomain(PersonRecord storage) => new()
    {
        Id = storage.Id,
        Nombre = storage.Nombre,
        Apellido = storage.Apellido,
        DNI = storage.DNI,
        Autos = string.IsNullOrWhiteSpace(storage.Autos)
        ? []
        : [.. storage.Autos.Split(',').Select(int.Parse)]
    };
}
