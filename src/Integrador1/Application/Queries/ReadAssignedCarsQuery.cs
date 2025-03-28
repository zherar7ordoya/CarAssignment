using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Extensions;

namespace Integrador.Application.Queries
{
    public class ReadAssignedCarsQuery : IReadQuery<List<AssignedCarDTO>>
    {
        public (bool Success, List<AssignedCarDTO>? Result, Exception Error) Execute()
        {
            var personaRepository = new GenericRepository<Person>();
            var personas = personaRepository.GetAll();

            if (personas == null)
            {
                return (false, null, new Exception("Error al listar personas."));
            }

            var autosAsignados = personas
                    .Where(persona => persona.Autos != null)
                    .SelectMany(persona => persona.Autos
                        .Select(auto => new AssignedCarDTO
                        (
                            auto.Marca ?? "Desconocido",
                            auto.Año,
                            auto.Modelo ?? "Desconocido",
                            auto.Patente ?? "Sin patente",
                            persona.DNI ?? "Sin DNI",
                            persona.GetApellidoNombre()
                        )))
                    .ToList();

            return autosAsignados.Count == 0
                ? (false, null, new Exception("No hay autos asignados"))
                : (true, autosAsignados, null!);
        }

        public void Undo() { }
    }
}
