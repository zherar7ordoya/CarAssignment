using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos
{
    public class ReadAutosDisponiblesCommand : IReadCommand<List<Auto>>
    {
        public (bool Success, List<Auto>? Result, string ErrorMessage) Execute()
        {
            var autoRepository = new AutoRepository();
            return autoRepository.ReadDisponibles() is List<Auto> autos
                ? (true, autos, string.Empty)
                : (false, null, "Error al listar autos disponibles");
        }

        public void Undo() { }
    }
}
