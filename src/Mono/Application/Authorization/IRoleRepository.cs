namespace Integrador.Application.Authorization;

public interface IRoleRepository
{
    Role? GetByName(string name);
    List<Role> GetAll();
    void Save(Role role);
    void Delete(string name);
}

