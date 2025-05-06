using CarAssignment.Application.DTOs;

namespace CarAssignment.Application.Interfaces.Services
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