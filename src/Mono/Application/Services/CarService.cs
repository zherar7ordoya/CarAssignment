using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Application.Interfaces.Services;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

// TODO: Bring logging to the service layer from the repository layer.
public class CarService
(
    IRepository<Car> repository,
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
        var cars = repository.ReadAll();
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
        var car = repository.ReadById(carDto.Id);
        
        if (car is null)
        {
            messenger.ShowInformation("Car not found.");
            return;
        }

        // Verify patente uniqueness excluding the current car
        var newPatente = carDto.Patente.Trim();
        var newMarca = carDto.Marca.Trim();
        var newModelo = carDto.Modelo.Trim();
        var newAño = carDto.Año;
        var newPrecio = carDto.Precio;

        var exists = repository.ReadAll()
                               .Any(p => p.Patente == newPatente && p.Id != carDto.Id);

        if (exists)
        {
            messenger.ShowError("Car with the same patente already exists.");
            return;
        }

        // Update car properties
        car.Patente = newPatente;
        car.Marca = newMarca;
        car.Modelo = newModelo;
        car.Año = newAño;
        car.Precio = newPrecio;

        repository.Update(car);
    }

    public void DeleteCar(int carId)
    {
        var car = repository.ReadById(carId);

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
        var cars = repository.ReadAll();

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
