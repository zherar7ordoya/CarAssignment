using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence.SQLite.Records;

namespace Integrador.Infrastructure.Persistence.SQLite.Mappers;

public class CarMapper : IMapper<Car, CarRecord>
{
    public CarRecord ToStorage(Car entity) => new()
    {
        Id = entity.Id,
        Patente = entity.Patente,
        Marca = entity.Marca,
        Modelo = entity.Modelo,
        Año = entity.Año,
        Precio = entity.Precio,
        DueñoId = entity.DueñoId
    };

    public Car ToDomain(CarRecord storage) => new()
    {
        Id = storage.Id,
        Patente = storage.Patente,
        Marca = storage.Marca,
        Modelo = storage.Modelo,
        Año = storage.Año,
        Precio = storage.Precio,
        DueñoId = storage.DueñoId ?? 0
    };
}
