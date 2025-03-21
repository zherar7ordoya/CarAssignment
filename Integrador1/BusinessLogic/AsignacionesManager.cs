using Integrador.Core;
using Integrador.Infrastructure.Persistence;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic;

public static class AsignacionesManager
{
    public static void AsignarAuto(Persona persona, Auto auto)
    {
        if (auto.Dueño is not null)
        {
            throw new InvalidOperationException("El auto ya tiene un dueño.");
        }

        persona.Autos.Add(auto);
        auto.Dueño = persona;

        var autoRepository = new AutoRepository();
        var personaRepository = new PersonaRepository();

        autoRepository.Update(auto);
        personaRepository.Update(persona);
    }

    public static void DesasignarAuto(Persona persona, Auto auto)
    {
        if (persona.Autos.Remove(auto))
        {
            auto.Dueño = null;

            var autoRepository = new AutoRepository();
            var personaRepository = new PersonaRepository();

            autoRepository.Update(auto);
            personaRepository.Update(persona);
        }
        else
        {
            throw new InvalidOperationException("El auto no pertenece a la persona.");
        }
    }
}
