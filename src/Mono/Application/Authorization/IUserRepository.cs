namespace Integrador.Application.Authorization;

public interface IUserRepository
{
    void Create(User user);

    List<User> ReadAll();
    User? GetById(int id);
    User? GetByUsername(string username);

    void Update(User user);
    void Delete(string username);
}

