namespace Integrador.Application.Interfaces
{
    public interface IAssignmentService
    {
        bool AssignCar(int carId, int personId);
        bool RemoveCar(int carId, int personId);
    }
}