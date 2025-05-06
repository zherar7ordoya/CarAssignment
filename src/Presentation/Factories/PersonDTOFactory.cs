using CarAssignment.Application.DTOs;
using CarAssignment.Application.Interfaces.Utilities;

namespace CarAssignment.Presentation.Factories;

public class PersonDTOFactory : IPersonFactory
{
    public PersonDTO CreateDefault()
    {
        return new PersonDTO(0, "12345678", "First Name", "Last Name", []);
    }
}
