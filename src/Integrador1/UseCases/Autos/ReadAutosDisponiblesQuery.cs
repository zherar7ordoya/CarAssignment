using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Autos
{
    public class ReadAutosDisponiblesQuery : IReadQuery<List<Auto>>
    {
        public (bool Success, List<Auto>? Result, Exception Error) Execute()
        {
            var repository = new GenericRepository<Auto>();
            var autos = repository.Read().Where(auto => auto.DueñoId == 0).ToList();

            return autos.Count != 0
                ? (true, autos, null!)
                : (false, null, new Exception("Error al listar autos disponibles."));
        }

        public void Undo() { }
    }
}
