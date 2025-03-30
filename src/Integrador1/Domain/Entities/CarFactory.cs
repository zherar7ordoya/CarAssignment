using Integrador.Domain.Interfaces;

namespace Integrador.Domain.Entities;

public class CarFactory : ICarFactory
{
    public Car CreateDefault()
    {
        return new Car("12345678", "Marca", "Modelo", 2020, 10000); // Lógica de creación en Dominio
    }
}
