using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces
{
    public interface ICarManager
    {
        Task CreateCar(CarDTO carDto, CancellationToken ct);
        Task DeleteCar(int carId, CancellationToken ct);
        Task<List<CarDTO>> GetAvailableCars(CancellationToken ct);
        Task UpdateCar(CarDTO carDto, CancellationToken ct);
    }
}