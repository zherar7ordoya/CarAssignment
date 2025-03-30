using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Queries;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class ReadPersonsHandler(
    IGenericRepository<Person> repository)
    : IRequestHandler<ReadPersonsQuery, List<Person>>
{
    private readonly IGenericRepository<Person> _repository = repository;

    public Task<List<Person>> Handle(ReadPersonsQuery request, CancellationToken ct)
    {
        try
        {
            var persons = _repository.GetAll();
            return Task.FromResult(persons);
        }
        catch (Exception ex)
        {
            throw new DomainException("Error al listar personas: " + ex.Message);
        }
    }
}
