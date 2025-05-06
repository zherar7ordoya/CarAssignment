using CarAssignment.Application.Security.Core;

namespace CarAssignment.Application.Security.Contracts;

public interface IRoleRepository
{
    Role? GetByName(string name);
    List<Role> GetAll();
    void Save(Role role);
    void Delete(string name);
}

