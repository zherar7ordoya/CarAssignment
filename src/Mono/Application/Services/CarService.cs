using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class CarService(IGenericRepository<Car> repository, IExceptionHandler exceptionHandler) : ICarManager
{
    public async Task CreateCar(CarDTO carDto, CancellationToken ct)
    {
        var car = new Car(carDto.Patente.Trim(),
                          carDto.Marca.Trim(),
                          carDto.Modelo.Trim(),
                          carDto.Año,
                          carDto.Precio);

        await repository.CreateAsync(car, ct);
    }

    public async Task UpdateCar(CarDTO carDto, CancellationToken ct)
    {
        var car = await repository.GetByIdAsync(carDto.Id, ct);
        
        if (car is null)
        {
            exceptionHandler.Handle("El auto no existe.");
            return;
        }

        car.Patente = carDto.Patente.Trim();
        car.Marca = carDto.Marca.Trim();
        car.Modelo = carDto.Modelo.Trim();
        car.Año = carDto.Año;
        car.Precio = carDto.Precio;

        await repository.UpdateAsync(car, ct);
    }

    public async Task DeleteCar(int carId, CancellationToken ct)
    {
        var car = await repository.GetByIdAsync(carId, ct);

        if (car is null)
        {
            exceptionHandler.Handle("El auto no existe.");
            return;
        }

        if (car.HasOwner())
        {
            exceptionHandler.Handle("No se puede eliminar un auto que tiene dueño.");
            return;
        }

        await repository.DeleteAsync(carId, ct);
    }

    public async Task<List<CarDTO>> GetAvailableCars(CancellationToken ct)
    {
        var cars = await repository.GetAllAsync(ct);

        var available = cars
            .Where(c => c.DueñoId == 0)
            .Select(c => new CarDTO
            (
                c.Id,
                c.Patente,
                c.Marca,
                c.Modelo,
                c.Año,
                c.Precio,
                c.DueñoId
            ))
            .ToList();

        return available;
    }
}
