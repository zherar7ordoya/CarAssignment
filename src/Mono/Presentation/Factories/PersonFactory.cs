using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;

namespace Integrador.Presentation.Factories;

public class PersonFactory : IPersonFactory
{
    public PersonDTO CreateDefault()
    {
        return new PersonDTO(0, "12345678", "Nombre", "Apellido", []);
    }
}
