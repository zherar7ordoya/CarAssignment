using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Utilities;

namespace Integrador.Presentation.Factories;

public class CarDTOFactory : ICarFactory
{
    public CarDTO CreateDefault()
    {
        return new CarDTO(0, "12345678", "Brand", "Model", 0, 0, 0);
    }
}
