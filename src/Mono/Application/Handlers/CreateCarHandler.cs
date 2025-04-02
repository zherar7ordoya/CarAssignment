using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class CreateCarHandler(IGenericRepository<Car> repository)
           : IRequestHandler<CreateCarCommand, Unit>
{
    public async Task<Unit> Handle(CreateCarCommand request, CancellationToken ct)
    {
        var car = new Car
        (
            request.CarDTO.Patente,
            request.CarDTO.Marca,
            request.CarDTO.Modelo,
            request.CarDTO.Año,
            request.CarDTO.Precio
        );

        await repository.CreateAsync(car, ct);

        return Unit.Value;
    }
}
