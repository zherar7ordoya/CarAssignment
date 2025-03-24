using Integrador.Infrastructure.Repositories;

using static Integrador.ViewController;

namespace Integrador.BusinessLogic.Commands.Autos
{
    public class ReadAutosAsignadosCommand : IReadCommand<List<AutoAsignado>>
    {
        public (bool Success, List<AutoAsignado>? Result, string ErrorMessage) Execute()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.Read();

            if (personas == null)
            {
                return (false, null, "Error al listar personas");
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
                            GetApellidoNombre(persona)
                        )))
                    .ToList();

            return autosAsignados.Count == 0
                ? (false, null, "No hay autos asignados")
                : (true, autosAsignados, string.Empty);
        }

        public void Undo() { }
    }
}
