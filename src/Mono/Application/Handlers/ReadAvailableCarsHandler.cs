using MediatR;
using Integrador.Application.DTOs;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAvailableCarsHandler(IGenericRepository<Car> repository)
           : IRequestHandler<ReadAvailableCarsQuery, List<CarDTO>>
{
    public async Task<List<CarDTO>> Handle(ReadAvailableCarsQuery request,
                                           CancellationToken ct)
    {
        var cars = await repository.GetAllAsync(ct);
        var available = cars
            .Where(c => c.DueñoId == 0)
            .Select(c => new CarDTO
            (
                c.Id,
                c.Patente,
                c.Marca,
                c.Modelo,
                c.Año,
                c.Precio,
                c.DueñoId
            ))
            .ToList();

        return available;
    }
}
