using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class PersonService
(
    IRepository<Person> repository,
    IMessenger messenger
) : IPersonService
{
    public void CreatePerson(PersonDTO personDto)
    {
        var person = new Person(personDto.DNI.Trim(),
                                personDto.Nombre.Trim(),
                                personDto.Apellido.Trim());

        // Verify dni uniqueness
        var persons = repository.GetAll();
        var exists = persons.FirstOrDefault(c => c.DNI == person.DNI);
        if (exists is not null)
        {
            messenger.ShowError("Person with the same DNI already exists.");
            return;
        }

        repository.Create(person);
    }

    public void UpdatePerson(PersonDTO personDto)
    {
        var person = repository.GetById(personDto.Id);

        if (person is null)
        {
            messenger.ShowInformation("Person not found");
            return;
        }

        var newNombre = personDto.Nombre.Trim();
        var newApellido = personDto.Apellido.Trim();
        var newDNI = personDto.DNI.Trim();

        // Verify dni uniqueness excluding the current person
        var exists = repository.GetAll()
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

        repository.Update(person);
    }


    public void DeletePerson(int personId)
    {
        var person = repository.GetById(personId);

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

        repository.Delete(personId);
    }

    public List<PersonDTO> GetPersons()
    {
        var persons = repository.GetAll();

        return [.. persons
            .Select(p => new PersonDTO
            (
                p.Id,
                p.DNI,
                p.Nombre,
                p.Apellido,
                [.. p.GetCarsList().Select(a => new CarDTO
                (
                    a.Id,
                    a.Patente,
                    a.Marca,
                    a.Modelo,
                    a.Año,
                    a.Precio,
                    a.DueñoId
                ))]
            ))];
    }

    public List<AssignedCarDTO> GetAssignedCars()
    {
        var persons = repository.GetAll();

        var assigned = persons
            .SelectMany(persona => persona
            .GetCarsList()
            .Select(auto => new AssignedCarDTO
            (
                auto.Marca ?? "Desconocido",
                auto.Año,
                auto.Modelo ?? "Desconocido",
                auto.Patente ?? "Sin patente",
                persona.GetIdentityNumber(),
                persona.GetNameSurname()
            )))
            .ToList();

        return assigned;
    }
}
