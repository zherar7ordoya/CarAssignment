using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface IPersonService
    {
        bool CreatePerson(PersonDTO personDto);
        bool DeletePerson(int personId);
        List<AssignedCarDTO> GetAssignedCars();
        List<PersonDTO> GetPersons();
        bool UpdatePerson(PersonDTO personDto);
    }
}