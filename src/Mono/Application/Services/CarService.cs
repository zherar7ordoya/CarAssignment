using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class CarService
(
    IGenericRepository<Car> repository,
    IMessenger messenger
) : ICarService
{
    public void CreateCar(CarDTO carDto)
    {
        var car = new Car(carDto.Patente.Trim(),
                          carDto.Marca.Trim(),
                          carDto.Modelo.Trim(),
                          carDto.Año,
                          carDto.Precio);

        // Verify patente uniqueness
        var cars = repository.GetAll();
        var exists = cars.FirstOrDefault(c => c.Patente == car.Patente);
        if (exists is not null)
        {
            messenger.ShowError("Car with the same patente already exists.");
            return;
        }

        repository.Create(car);
    }

    public void UpdateCar(CarDTO carDto)
    {
        var car = repository.GetById(carDto.Id);
        
        if (car is null)
        {
            messenger.ShowInformation("Car not found.");
            return;
        }

        car.Patente = carDto.Patente.Trim();
        car.Marca = carDto.Marca.Trim();
        car.Modelo = carDto.Modelo.Trim();
        car.Año = carDto.Año;
        car.Precio = carDto.Precio;

        // Verify patente uniqueness
        var cars = repository.GetAll();
        var exists = cars.FirstOrDefault(c => c.Patente == car.Patente);
        if (exists is not null)
        {
            messenger.ShowError("Car with the same patente already exists.");
            return;
        }

        repository.Update(car);
    }

    public void DeleteCar(int carId)
    {
        var car = repository.GetById(carId);

        if (car is null)
        {
            messenger.ShowInformation("Car not found.");
            return;
        }

        if (car.HasOwner())
        {
            messenger.ShowError("Cannot delete a car that has an owner.");
            return;
        }

        repository.Delete(carId);
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
