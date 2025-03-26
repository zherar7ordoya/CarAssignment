using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Autos
{
    public class ReadAutosDisponiblesQuery : IReadQuery<List<Auto>>
    {
        public (bool Success, List<Auto>? Result, Exception Error) Execute()
        {
            var autoRepository = new AutoRepository();
            return autoRepository.ReadDisponibles() is List<Auto> autos
                ? (true, autos, null!)
                : (false, null, new Exception("Error al listar autos disponibles."));
        }

        public void Undo() { }
    }
}
