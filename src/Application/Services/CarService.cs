using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Services;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Interfaces.Persistence;

namespace Integrador.Application.Services;

public class CarService
(
    IRepository<Car> repository,
    IMessenger messenger
) : ICarService
{
    public void CreateCar(CarDTO carDto)
    {
        var car = new Car(carDto.LicensePlate.Trim(),
                          carDto.Brand.Trim(),
                          carDto.Model.Trim(),
                          carDto.Year,
                          carDto.Price);

        // Verify patente uniqueness
        var cars = repository.ReadAll();
        var exists = cars.FirstOrDefault(c => c.LicensePlate == car.LicensePlate);
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
        var newLicensePlate = carDto.LicensePlate.Trim();
        var newBrand = carDto.Brand.Trim();
        var newModel = carDto.Model.Trim();
        var newYear = carDto.Year;
        var newPrice = carDto.Price;

        var exists = repository.ReadAll()
                               .Any(p => p.LicensePlate == newLicensePlate && p.Id != carDto.Id);

        if (exists)
        {
            messenger.ShowError("Car with the same patente already exists.");
            return;
        }

        // Update car properties
        car.LicensePlate = newLicensePlate;
        car.Brand = newBrand;
        car.Model = newModel;
        car.Year = newYear;
        car.Price = newPrice;

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
            .Where(car => car.PersonId == 0)
            .Select(dto => new CarDTO
            (
                dto.Id,
                dto.LicensePlate,
                dto.Brand,
                dto.Model,
                dto.Year,
                dto.Price,
                dto.PersonId
            ))
            .ToList();

        return available;
    }
}
