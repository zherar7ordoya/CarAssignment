using Integrador.Application.Authorization;

namespace Integrador.Application.Interfaces;

public interface IAuthService
{
    bool Login(string username, string password);
    User? GetCurrentUser();
    List<User> GetAllUsers();

    void SaveUser(User user);   // Alta o modificación
    void DeleteUser(int id);    // Baja
}
