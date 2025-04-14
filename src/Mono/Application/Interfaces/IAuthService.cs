using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IAuthService
{
    bool Login(string username, string password);
    User? GetCurrentUser();
    List<User> GetAllUsers();
}
