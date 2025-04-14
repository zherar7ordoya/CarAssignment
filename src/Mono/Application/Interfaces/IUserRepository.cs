using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetByUsername(string username);
    User? GetUserById(int id);

    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id); // faltaba esta
}
