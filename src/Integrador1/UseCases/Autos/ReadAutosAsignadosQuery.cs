using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Adapters.Presentation.ViewModels;
using Integrador.Entities;
using Integrador.Infrastructure.Extensions;

namespace Integrador.UseCases.Autos
{
    public class ReadAutosAsignadosQuery : IReadQuery<List<AssignedAutoViewModel>>
    {
        public (bool Success, List<AssignedAutoViewModel>? Result, Exception Error) Execute()
        {
            var personaRepository = new GenericRepository<Persona>();
            var personas = personaRepository.Read();

            if (personas == null)
            {
                return (false, null, new Exception("Error al listar personas."));
            }

            var autosAsignados = personas
                    .Where(persona => persona.Autos != null)
                    .SelectMany(persona => persona.Autos
                        .Select(auto => new AssignedAutoViewModel
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
