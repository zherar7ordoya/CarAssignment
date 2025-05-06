namespace CarAssignment.Application.Interfaces.Services
{
    public interface IAssignmentService
    {
        void AssignCar(int carId, int personId);
        void RemoveCar(int carId, int personId);
    }
}