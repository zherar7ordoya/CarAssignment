namespace Integrador.Application.Interfaces
{
    public interface IAssignmentManager
    {
        Task AssignCar(int carId, int personId, CancellationToken ct);
        Task RemoveCar(int carId, int personId, CancellationToken ct);
    }
}