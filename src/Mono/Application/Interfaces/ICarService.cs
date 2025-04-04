using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface ICarService
    {
        void CreateCar(CarDTO carDto);
        void DeleteCar(int carId);
        List<CarDTO> GetAvailableCars();
        void UpdateCar(CarDTO carDto);
    }
}