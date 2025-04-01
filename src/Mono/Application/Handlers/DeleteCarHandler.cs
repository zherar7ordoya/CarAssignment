using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class DeleteCarHandler(IGenericRepository<Car> repository)
           : IRequestHandler<DeleteCarCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken ct)
    {
        // Obtenemos el auto usando su Id
        var existingCar = await repository.GetByIdAsync(request.CarId, ct) ?? throw new ApplicationException("El auto no existe.");

        // Validación de negocio: No se puede eliminar un auto que tiene dueño
        if (existingCar.HasOwner())
        {
            throw new ApplicationException("No se puede eliminar un auto que tiene dueño.");
        }

        // Eliminación
        await repository.DeleteAsync(existingCar, ct);

        return Unit.Value;
    }
}
