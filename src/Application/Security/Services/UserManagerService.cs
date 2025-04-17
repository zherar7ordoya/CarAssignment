using Integrador.Application.Security.Contracts;
using Integrador.Application.Security.Core;
using Integrador.Domain.Entities;

namespace Integrador.Application.Security.Services;

public class UserManagerService(IUserRepository userRepository) : IUserManagerService
{
    public void CreateUser(string username, string password)
    {
        if (userRepository.GetByUsername(username) is not null)
        {
            throw new InvalidOperationException("Username already exists.");
        }

        var hashedPassword = PasswordHasher.Hash(password);

        var newUser = new User 
        {
            Username = username,
            PasswordHash = hashedPassword,
            RoleNames = [],
            SpecialPermissions = []
        };
        userRepository.Update(newUser);
    }

    public void DeleteUser(string username)
    {
        userRepository.Delete(username);
    }

    public void UpdatePassword(string username, string newPassword)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        user.PasswordHash = PasswordHasher.Hash(newPassword);
        userRepository.Update(user);
    }

    public User? GetUserByUsername(string username)
    {
        return userRepository.GetByUsername(username);
    }

    public List<User> GetAllUsers()
    {
        return userRepository.ReadAll();
    }

    public void SetUserRoles(string username, List<string> roleNames)
    {
        var user = userRepository.GetByUsername(username)
               ?? throw new InvalidOperationException("User not found.");

        user.RoleNames = [.. roleNames.Distinct()];
        userRepository.Update(user);
    }

    public void SetUserSpecialPermissions(string username, List<Permission> permissions)
    {
        var user = userRepository.GetByUsername(username)
               ?? throw new InvalidOperationException("User not found.");

        user.SpecialPermissions = [.. permissions.Distinct()];
        userRepository.Update(user);
    }

}

