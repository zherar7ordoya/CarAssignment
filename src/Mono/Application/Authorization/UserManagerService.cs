using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public class UserManagerService(IUserRepository userRepository) : IUserManagerService
{
    public void CreateUser(string username, string password)
    {
        if (userRepository.GetByUsername(username) is not null)
            throw new InvalidOperationException("Username already exists.");

        var hashedPassword = HashPassword(password);

        var newUser = new User 
        {
            Username = username,
            PasswordHash = hashedPassword,
            RoleNames = [],
            SpecialPermissions = []
        };
        userRepository.Save(newUser);
    }

    public void DeleteUser(string username)
    {
        userRepository.Delete(username);
    }

    public void UpdatePassword(string username, string newPassword)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        user.PasswordHash = HashPassword(newPassword);
        userRepository.Update(user);
    }

    public User? GetUserByUsername(string username)
    {
        return userRepository.GetByUsername(username);
    }

    public List<User> GetAllUsers()
    {
        return userRepository.GetAll();
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
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

