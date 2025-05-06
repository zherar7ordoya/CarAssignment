using CarAssignment.Application.DTOs;

namespace CarAssignment.Application.Interfaces.Utilities;

public interface IPersonFactory
{
    PersonDTO CreateDefault();
}
