using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Asignaciones;

public class DissociateAutoCommand(Persona persona, Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        try
        {
            if (!persona.Autos.Remove(auto))
            {
                return (false, new Exception("El auto no pertenece a la persona."));
            }

            auto.Dueño = null;

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
