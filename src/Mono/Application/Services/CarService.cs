using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class CarService(IGenericRepository<Car> repository) : ICarManager
{
    public async Task CreateCar(CarDTO carDto, CancellationToken ct)
    {
        var car = new Car(carDto.Patente,
                          carDto.Marca,
                          carDto.Modelo,
                          carDto.Año,
                          carDto.Precio);

        await repository.CreateAsync(car, ct);
    }

    public async Task UpdateCar(CarDTO carDto, CancellationToken ct)
    {
        var car = await repository.GetByIdAsync(carDto.Id, ct) ?? throw new Exception("El auto no existe.");

        car.Patente = carDto.Patente;
        car.Marca = carDto.Marca;
        car.Modelo = carDto.Modelo;
        car.Año = carDto.Año;
        car.Precio = carDto.Precio;

        await repository.UpdateAsync(car, ct);
    }

    public async Task DeleteCar(int carId, CancellationToken ct)
    {
        var car = await repository.GetByIdAsync(carId, ct) ?? throw new Exception("El auto no existe.");

        if (car.HasOwner())
        {
            throw new ApplicationException("No se puede eliminar un auto que tiene dueño.");
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
