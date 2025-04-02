using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Managers;

public class CarManager(IGenericRepository<Car> repository)
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
        await repository.DeleteAsync(carId, ct);
    }
}
