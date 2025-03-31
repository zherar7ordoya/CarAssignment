using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAvailableCarsHandler(IGenericRepository<Car> repository)
    : IRequestHandler<ReadAvailableCarsQuery, List<Car>>
{
    private readonly IGenericRepository<Car> _repository = repository;

    public async Task<List<Car>> Handle(ReadAvailableCarsQuery request, CancellationToken ct)
    {
        var cars = await _repository.GetAllAsync(ct);
        var availableCars = cars.Where(c => c.DueñoId == 0).ToList();
        return availableCars;
    }
}
