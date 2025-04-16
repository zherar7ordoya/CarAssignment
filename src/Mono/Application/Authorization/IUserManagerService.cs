using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public interface IUserManagerService
{
    void CreateUser(string username, string password);
    void DeleteUser(string username);
    void UpdatePassword(string username, string newPassword);
    User? GetUserByUsername(string username);
    List<User> GetAllUsers();
    void SetUserRoles(string username, List<string> roleNames);
    void SetUserSpecialPermissions(string username, List<Permission> permissions);
}

