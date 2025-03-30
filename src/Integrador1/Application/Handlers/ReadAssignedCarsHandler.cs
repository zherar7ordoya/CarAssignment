using MediatR;
using Integrador.Application.DTOs;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Shared.Extensions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadAssignedCarsHandler(IGenericRepository<Person> repository) : IRequestHandler<ReadAssignedCarsQuery, List<AssignedCarDTO>>
{
    private readonly IGenericRepository<Person> _repository = repository;

    public Task<List<AssignedCarDTO>> Handle(ReadAssignedCarsQuery request, CancellationToken ct)
    {
        var personas = _repository.GetAll();
        var autosAsignados = personas
            .SelectMany(persona => persona.Autos
                .Select(auto => new AssignedCarDTO(
                    auto.Marca ?? "Desconocido",
                    auto.Año,
                    auto.Modelo ?? "Desconocido",
                    auto.Patente ?? "Sin patente",
                    persona.DNI ?? "Sin DNI",
                    persona.GetApellidoNombre() // Asegúrate de que este método exista
                )))
            .ToList();

        return Task.FromResult(autosAsignados);
    }
}
