using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces.Utilities;

public interface IPersonFactory
{
    PersonDTO CreateDefault();
}
