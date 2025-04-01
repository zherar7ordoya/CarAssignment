using MediatR;
using Integrador.Application.DTOs;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAssignedCarsHandler(IGenericRepository<Person> repository)
           : IRequestHandler<ReadAssignedCarsQuery, List<AssignedCarDTO>>
{
    public async Task<List<AssignedCarDTO>> Handle(ReadAssignedCarsQuery request,
                                                   CancellationToken ct)
    {
        var persons = await repository.GetAllAsync(ct);
        var assigned = persons
            .SelectMany(persona => persona
            .GetListaAutos()
            .Select(auto => new AssignedCarDTO
            (
                auto.Marca ?? "Desconocido",
                auto.Año,
                auto.Modelo ?? "Desconocido",
                auto.Patente ?? "Sin patente",
                persona.GetDNI(),
                persona.GetApellidoNombre()
            )))
            .ToList();

        return assigned;
    }
}
