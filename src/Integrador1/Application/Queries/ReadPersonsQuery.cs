using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Application.Queries;

public class ReadPersonsQuery : IReadQuery<List<Person>>
{
    public (bool Success, List<Person>? Result, Exception Error) Execute()
    {
        var personaRepository = new GenericRepository<Person>();
        return personaRepository.Read() is List<Person> personas
            ? (true, personas, null!)
            : (false, null, new Exception("Error al listar personas."));
    }

    public void Undo() { }
}
