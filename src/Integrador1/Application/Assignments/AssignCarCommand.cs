using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Application.Assignments;

public class AssignCarCommand(Person persona, Car auto) : ICommand
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
