using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Application.Queries
{
    public class ReadAvailableCarsQuery : IReadQuery<List<Car>>
    {
        public (bool Success, List<Car>? Result, Exception Error) Execute()
        {
            var repository = new GenericRepository<Car>();
            var autos = repository.GetAll().Where(auto => auto.DueñoId == 0).ToList();

            return autos.Count != 0
                ? (true, autos, null!)
                : (false, null, new Exception("Error al listar autos disponibles."));
        }

        public void Undo() { }
    }
}
