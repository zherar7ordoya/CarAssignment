using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IUserRepository
{
    User? GetByUsername(string username);
    List<User> GetAll();
}
