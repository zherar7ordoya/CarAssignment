using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Shared.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Integrador.Application.Commands;

namespace Integrador.Application.Handlers;

public class DeleteCarHandler(IGenericRepository<Car> repository) : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly IGenericRepository<Car> _repository = repository;

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken ct)
    {
        // 1. Validación de dominio (usando lógica encapsulada en Car)
        request.Car.EnsureCanBeDeleted();

        // 2. Eliminar auto
        return await Task.FromResult(_repository.Delete(request.Car));
    }
}
