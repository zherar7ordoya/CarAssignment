using Integrador.Domain.Interfaces;

namespace Integrador.Domain.Entities;

public class PersonFactory : IPersonFactory
{
    public Person CreateDefault()
    {
        return new Person("12345678", "Nombre", "Apellido"); // Lógica de creación en Dominio
    }
}