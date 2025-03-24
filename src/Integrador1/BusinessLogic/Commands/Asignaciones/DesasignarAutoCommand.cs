using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Asignaciones;

public class DesasignarAutoCommand(Persona persona, Auto auto) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        try
        {
            if (!persona.Autos.Remove(auto))
            {
                return (false, "El auto no pertenece a la persona.");
            }

            auto.Dueño = null;

            var autoRepository = new AutoRepository();
            var personaRepository = new PersonaRepository();

            autoRepository.Update(auto);
            personaRepository.Update(persona);

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public void Undo() { }
}
