using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Factories;

public class PersonFactory : IPersonFactory
{
    public Person CreateDefault()
    {
        return new Person("12345678", "Nombre", "Apellido"); // Lógica de creación en Dominio
    }
}