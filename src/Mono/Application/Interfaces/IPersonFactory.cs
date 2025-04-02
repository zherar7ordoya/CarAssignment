using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces;

public interface IPersonFactory
{
    PersonDTO CreateDefault();
}
