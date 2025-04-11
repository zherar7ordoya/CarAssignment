using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Application.Interfaces.Services;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class PersonService
(
    IRepository<Car> carRepository,
    IRepository<Person> personRepository,
    IMessenger messenger
) : IPersonService
{
    public void CreatePerson(PersonDTO personDto)
    {
        var person = new Person(personDto.IdentityNumber.Trim(),
                                personDto.FirstName.Trim(),
                                personDto.LastName.Trim());

        // Verify dni uniqueness
        var persons = personRepository.ReadAll();
        var exists = persons.FirstOrDefault(c => c.IdentityNumber == person.IdentityNumber);
        if (exists is not null)
        {
            messenger.ShowError("Person with the same DNI already exists.");
            return;
        }

        personRepository.Create(person);
    }

    public void UpdatePerson(PersonDTO personDto)
    {
        var person = personRepository.ReadById(personDto.Id);

        if (person is null)
        {
            messenger.ShowInformation("Person not found");
            return;
        }

        var newIdentityNumber = personDto.IdentityNumber.Trim();
        var newFirstName = personDto.FirstName.Trim();
        var newLastName = personDto.LastName.Trim();

        // Verify identity number uniqueness excluding the current person
        var exists = personRepository.ReadAll()
                               .Any(p => p.IdentityNumber == newIdentityNumber && p.Id != personDto.Id);

        if (exists)
        {
            messenger.ShowError("Another person with the same DNI already exists.");
            return;
        }

        // Update person properties
        person.FirstName = newFirstName;
        person.LastName = newLastName;
        person.IdentityNumber = newIdentityNumber;

        personRepository.Update(person);
    }


    public void DeletePerson(int personId)
    {
        var person = personRepository.ReadById(personId);

        if (person is null)
        {
            messenger.ShowInformation("Person not found");
            return;
        }

        if (person.HasCars())
        {
            messenger.ShowInformation("Cannot delete a person who has cars.");
            return;
        }

        personRepository.Delete(personId);
    }

    public List<PersonDTO> GetPersons()
    {
        var persons = personRepository.ReadAll();

        return [.. persons
            .Select(dto => new PersonDTO
            (
                dto.Id,
                dto.IdentityNumber,
                dto.FirstName,
                dto.LastName,
                [.. dto.CarIds
                .Select(carId => carRepository.ReadById(carId))
                .Where(car => car is not null) // Ensure car is not null
                .Select(car => new CarDTO
                (
                    car!.Id, // Use null-forgiving operator since we filtered nulls
                    car.LicensePlate,
                    car.Brand,
                    car.Model,
                    car.Year,
                    car.Price,
                    car.PersonId
                ))]
            ))];
    }

    public List<AssignedCarDTO> GetAssignedCars()
    {
        var persons = personRepository.ReadAll();

        var assigned = persons
            .SelectMany(person =>
            person.CarIds
            .Select(carId => carRepository.ReadById(carId))
            .Where(entitiy => entitiy is not null)
            .Select(car => new AssignedCarDTO
            (
                car!.Brand ?? "Desconocido",
                car.Year,
                car.Model ?? "Desconocido",
                car.LicensePlate ?? "Sin patente",
                person.GetIdentityNumber(),
                person.GetNameSurname()
            ))).ToList(); // Add ToList() here to explicitly convert to List<AssignedCarDTO>

        return assigned;
    }
}
