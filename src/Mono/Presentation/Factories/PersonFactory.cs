using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Utilities;

namespace Integrador.Presentation.Factories;

public class PersonFactory : IPersonFactory
{
    public PersonDTO CreateDefault()
    {
        return new PersonDTO(0, "12345678", "First Name", "Last Name", []);
    }
}
