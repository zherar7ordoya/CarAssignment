using static Integrador.Adapters.UI.ViewPresenter;
using Integrador.UseCases.Commands;
using Integrador.Adapters.Persistence;
using Integrador.Adapters.UI;
using Integrador.CrossCutting.Extensions;

namespace Integrador.UseCases.Autos
{
    public class ReadAutosAsignadosQuery : IReadQuery<List<AutoAsignado>>
    {
        public (bool Success, List<AutoAsignado>? Result, Exception Error) Execute()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.Read();

            if (personas == null)
            {
                return (false, null, new Exception("Error al listar personas."));
            }

            var autosAsignados = personas
                    .Where(persona => persona.Autos != null)
                    .SelectMany(persona => persona.Autos
                        .Select(auto => new AutoAsignado
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
