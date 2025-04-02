using Integrador.Application.DTOs;
using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface ICarFactory
{
    CarDTO CreateDefault();
}
