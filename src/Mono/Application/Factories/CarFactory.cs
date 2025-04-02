using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Factories;

public class CarFactory : ICarFactory
{
    public CarDTO CreateDefault()
    {
        return new CarDTO(0, "12345678", "Marca", "Modelo", 0, 0, 0);
    }
}
