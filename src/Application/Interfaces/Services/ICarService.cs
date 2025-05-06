using CarAssignment.Application.DTOs;

namespace CarAssignment.Application.Interfaces.Services;

public interface ICarService
{
    void CreateCar(CarDTO carDto);
    void DeleteCar(int carId);
    List<CarDTO> GetAvailableCars();
    void UpdateCar(CarDTO carDto);
}
