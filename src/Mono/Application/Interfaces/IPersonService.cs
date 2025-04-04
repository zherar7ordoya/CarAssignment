using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface IPersonService
    {
        void CreatePerson(PersonDTO personDto);
        void DeletePerson(int personId);
        List<AssignedCarDTO> GetAssignedCars();
        List<PersonDTO> GetPersons();
        void UpdatePerson(PersonDTO personDto);
    }
}