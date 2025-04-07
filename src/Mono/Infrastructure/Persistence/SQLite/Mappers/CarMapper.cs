using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence.SQLite.Records;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Persistence.SQLite.Mappers;

public class CarMapper : IEntityMapper<Car, CarRecord>
{
    public CarRecord ToStorage(Car entity) => new()
    {
        Id = entity.Id,
        Patente = entity.Patente,
        Marca = entity.Marca,
        Modelo = entity.Modelo,
        Año = entity.Año,
        Precio = entity.Precio
    };
    public Car ToDomain(CarRecord storage) => new()
    {
        Id = storage.Id,
        Patente = storage.Patente,
        Marca = storage.Marca,
        Modelo = storage.Modelo,
        Año = storage.Año,
        Precio = storage.Precio
    };
}
