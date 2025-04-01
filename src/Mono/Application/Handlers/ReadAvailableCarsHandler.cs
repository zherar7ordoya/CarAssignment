using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAvailableCarsHandler(IGenericRepository<Car> repository)
           : IRequestHandler<ReadAvailableCarsQuery, List<Car>>
{
    public async Task<List<Car>> Handle(ReadAvailableCarsQuery request, CancellationToken ct)
    {
        var cars = await repository.GetAllAsync(ct);
        var availableCars = cars.Where(c => c.DueñoId == 0).ToList();
        return availableCars;
    }
}
