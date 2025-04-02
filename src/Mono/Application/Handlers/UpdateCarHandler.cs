using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdateCarHandler(IGenericRepository<Car> repository)
           : IRequestHandler<UpdateCarCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken ct)
    {
        var carEntity = new Car(
            request.CarDTO.Patente,
            request.CarDTO.Marca,
            request.CarDTO.Modelo,
            request.CarDTO.Año,
            request.CarDTO.Precio
        )
        { Id = request.CarDTO.Id };

        _ = await repository.GetByIdAsync(carEntity.Id, ct) ?? throw new ApplicationException("El auto no existe.");
        await repository.UpdateAsync(carEntity, ct);

        return Unit.Value;
    }
}
