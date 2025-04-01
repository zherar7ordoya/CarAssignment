using MediatR;
using Integrador.Application.DTOs;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAssignedCarsHandler(IGenericRepository<Person> repository)
           : IRequestHandler<ReadAssignedCarsQuery, List<AssignedCarDTO>>
{
    public async Task<List<AssignedCarDTO>> Handle(ReadAssignedCarsQuery request, CancellationToken ct)
    {
        var personas = await repository.GetAllAsync(ct);
        var autosAsignados = personas
            .SelectMany(persona => persona.GetListaAutos()
                .Select(auto => new AssignedCarDTO(
                    auto.Marca ?? "Desconocido",
                    auto.Año,
                    auto.Modelo ?? "Desconocido",
                    auto.Patente ?? "Sin patente",
                    persona.GetDNI(),
                    persona.GetApellidoNombre() // Asegúrate de que este método exista
                )))
            .ToList();

        return autosAsignados;
    }
}
