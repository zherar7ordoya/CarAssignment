using CarAssignment.Application.DTOs;

namespace CarAssignment.Application.Interfaces.Utilities;

public interface ICarFactory
{
    CarDTO CreateDefault();
}
