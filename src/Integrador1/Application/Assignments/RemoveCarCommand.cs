using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Application.Assignments;

public class RemoveCarCommand(Person persona, Car auto) : ICommand
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

            var autoRepository = new GenericRepository<Car>();
            var personaRepository = new GenericRepository<Person>();

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
