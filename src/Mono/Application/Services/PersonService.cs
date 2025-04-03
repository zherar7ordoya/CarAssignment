using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

using System.CodeDom;

namespace Integrador.Application.Services;

public class PersonService
(
    IGenericRepository<Person> repository,
    IExceptionHandler exceptionHandler
) : IPersonManager
{
    public async Task CreatePerson(PersonDTO personDto, CancellationToken ct)
    {
        var person = new Person(personDto.Nombre,
                                personDto.Apellido,
                                personDto.DNI);

        await repository.CreateAsync(person, ct);
    }

    public async Task UpdatePerson(PersonDTO personDto, CancellationToken ct)
    {
        var person = await repository.GetByIdAsync(personDto.Id, ct) ?? throw new Exception("La persona no existe.");

        person.Nombre = personDto.Nombre;
        person.Apellido = personDto.Apellido;
        person.DNI = personDto.DNI;

        await repository.UpdateAsync(person, ct);
    }
    public async Task DeletePerson(int personId, CancellationToken ct)
    {
        var person = await repository.GetByIdAsync(personId, ct) ?? throw new Exception("La persona no existe.");

        if (person.HasCars())
        {
            exceptionHandler.Handle("No se puede eliminar una persona que tiene autos.");
            return;
        }

        await repository.DeleteAsync(personId, ct);
    }

    public async Task<List<PersonDTO>> GetPersons(CancellationToken ct)
    {
        var persons = await repository.GetAllAsync(ct);

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

    public async Task<List<AssignedCarDTO>> GetAssignedCars(CancellationToken ct)
    {
        var persons = await repository.GetAllAsync(ct);

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
