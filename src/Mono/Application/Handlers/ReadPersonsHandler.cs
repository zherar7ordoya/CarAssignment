using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Domain.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.DTOs;

namespace Integrador.Application.Handlers;

public class ReadPersonsHandler(IGenericRepository<Person> repository)
           : IRequestHandler<ReadPersonsQuery, List<PersonDTO>>
{
    public async Task<List<PersonDTO>> Handle(ReadPersonsQuery request, CancellationToken ct)
    {
        try
        {
            var persons = await repository.GetAllAsync(ct);
            return [.. persons.Select(p => new PersonDTO
            (
                p.Id,
                p.DNI,
                p.Nombre,
                p.Apellido,
                [.. p.Autos.Select(a => new CarDTO
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
        catch (Exception ex)
        {
            throw new DomainException("Error al listar personas: " + ex.Message);
        }
    }
}
