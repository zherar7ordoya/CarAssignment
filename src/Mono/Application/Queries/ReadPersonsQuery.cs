using Integrador.Application.Interfaces;
using Integrador.Application.DTOs;

using MediatR;

namespace Integrador.Application.Queries;

public record ReadPersonsQuery : IRequest<List<PersonDTO>>;