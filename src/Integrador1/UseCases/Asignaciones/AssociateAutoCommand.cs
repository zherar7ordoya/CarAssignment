using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Asignaciones;

public class AssociateAutoCommand(Persona persona, Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        try
        {
            if (auto.Dueño is not null)
            {
                return (false, new Exception("El auto ya tiene un dueño."));
            }

            persona.Autos.Add(auto);
            auto.Dueño = persona;

            var autoRepository = new AutoRepository();
            var personaRepository = new PersonaRepository();

            autoRepository.Update(auto);
            personaRepository.Update(persona);

            return (true, null!);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    public void Undo() { }
}
