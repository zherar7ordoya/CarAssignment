using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Factories;

public class PersonFactory : IPersonFactory
{
    public PersonDTO CreateDefault()
    {
        return new PersonDTO(0, "12345678", "Nombre", "Apellido", []);
    }
}
