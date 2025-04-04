using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface ICarService
    {
        bool CreateCar(CarDTO carDto);
        bool DeleteCar(int carId);
        List<CarDTO> GetAvailableCars();
        bool UpdateCar(CarDTO carDto);
    }
}