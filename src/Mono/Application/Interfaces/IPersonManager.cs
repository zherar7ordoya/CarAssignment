using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface IPersonManager
    {
        Task CreatePerson(PersonDTO personDto, CancellationToken ct);
        Task DeletePerson(int personId, CancellationToken ct);
        Task<List<AssignedCarDTO>> GetAssignedCars(CancellationToken ct);
        Task<List<PersonDTO>> GetPersons(CancellationToken ct);
        Task UpdatePerson(PersonDTO personDto, CancellationToken ct);
    }
}