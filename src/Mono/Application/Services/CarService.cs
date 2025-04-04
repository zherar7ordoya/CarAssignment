using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class CarService
(
    IGenericRepository<Car> repository,
    IExceptionHandler exceptionHandler
) : ICarService
{
    public bool CreateCar(CarDTO carDto)
    {
        var car = new Car(carDto.Patente.Trim(),
                          carDto.Marca.Trim(),
                          carDto.Modelo.Trim(),
                          carDto.Año,
                          carDto.Precio);

        return repository.Create(car);
    }

    public bool UpdateCar(CarDTO carDto)
    {
        var car = repository.GetById(carDto.Id);
        
        if (car is null)
        {
            exceptionHandler.Handle("El auto no existe.");
            return false;
        }

        car.Patente = carDto.Patente.Trim();
        car.Marca = carDto.Marca.Trim();
        car.Modelo = carDto.Modelo.Trim();
        car.Año = carDto.Año;
        car.Precio = carDto.Precio;

        return repository.Update(car);
    }

    public bool DeleteCar(int carId)
    {
        var car = repository.GetById(carId);

        if (car is null)
        {
            exceptionHandler.Handle("El auto no existe.");
            return false;
        }

        if (car.HasOwner())
        {
            exceptionHandler.Handle("No se puede eliminar un auto que tiene dueño.");
            return false;
        }

        return repository.Delete(carId);
    }

    public List<CarDTO> GetAvailableCars()
    {
        var cars = repository.GetAll();

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
