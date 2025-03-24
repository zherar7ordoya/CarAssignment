using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Asignaciones;

public class AsignarAutoCommand(Persona persona, Auto auto) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        try
        {
            if (auto.Dueño is not null)
            {
                return (false, "El auto ya tiene un dueño.");
            }

            persona.Autos.Add(auto);
            auto.Dueño = persona;

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
