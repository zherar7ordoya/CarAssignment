using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services;

public class PersonService
(
    IGenericRepository<Person> repository,
    IMessenger messenger
) : IPersonService
{
    public void CreatePerson(PersonDTO personDto)
    {
        var person = new Person(personDto.Nombre.Trim(),
                                personDto.Apellido.Trim(),
                                personDto.DNI.Trim());

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

        person.Nombre = personDto.Nombre.Trim();
        person.Apellido = personDto.Apellido.Trim();
        person.DNI = personDto.DNI.Trim();

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
