using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

// TODO: Bring logging to the service layer from the repository layer.
public class PersonService
(
    IRepository<Car> carRepository,
    IRepository<Person> personRepository,
    IMessenger messenger
) : IPersonService
{
    public void CreatePerson(PersonDTO personDto)
    {
        var person = new Person(personDto.DNI.Trim(),
                                personDto.Nombre.Trim(),
                                personDto.Apellido.Trim());

        // Verify dni uniqueness
        var persons = personRepository.ReadAll();
        var exists = persons.FirstOrDefault(c => c.DNI == person.DNI);
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

        var newNombre = personDto.Nombre.Trim();
        var newApellido = personDto.Apellido.Trim();
        var newDNI = personDto.DNI.Trim();

        // Verify dni uniqueness excluding the current person
        var exists = personRepository.ReadAll()
                               .Any(p => p.DNI == newDNI && p.Id != personDto.Id);

        if (exists)
        {
            messenger.ShowError("Another person with the same DNI already exists.");
            return;
        }

        // Update person properties
        person.Nombre = newNombre;
        person.Apellido = newApellido;
        person.DNI = newDNI;

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
            .Select(p => new PersonDTO
            (
                p.Id,
                p.DNI,
                p.Nombre,
                p.Apellido,
                [.. p.Autos
                .Select(carId => carRepository.ReadById(carId))
                .Where(car => car is not null) // Ensure car is not null
                .Select(car => new CarDTO
                (
                    car!.Id, // Use null-forgiving operator since we filtered nulls
                    car.Patente,
                    car.Marca,
                    car.Modelo,
                    car.Año,
                    car.Precio,
                    car.DueñoId
                ))]
            ))];
    }

    public List<AssignedCarDTO> GetAssignedCars()
    {
        var persons = personRepository.ReadAll();

        var assigned = persons
            .SelectMany(persona =>
            persona.Autos
            .Select(carId => carRepository.ReadById(carId))
            .Where(car => car is not null)
            .Select(auto => new AssignedCarDTO
            (
                auto!.Marca ?? "Desconocido",
                auto.Año,
                auto.Modelo ?? "Desconocido",
                auto.Patente ?? "Sin patente",
                persona.GetIdentityNumber(),
                persona.GetNameSurname()
            ))).ToList(); // Add ToList() here to explicitly convert to List<AssignedCarDTO>

        return assigned;
    }
}
