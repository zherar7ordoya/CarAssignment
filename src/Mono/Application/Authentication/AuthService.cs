using Integrador.Application.Authorization;
using Integrador.Application.Interfaces;
using Integrador.Domain.Enums.Authorization;

using System.Security.Cryptography;
using System.Text;

namespace Integrador.Application.Authentication;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    private User? _currentUser;

    public bool Login(string username, string password)
    {
        var user = userRepository.GetAll().FirstOrDefault(u => u.Username == username);
        if (user is null) return false;

        var inputPasswordHash = HashPassword(password);
        if (user.PasswordHash != inputPasswordHash) return false;

        _currentUser = user;
        return true;
    }

    public User? GetCurrentUser() => _currentUser;

    public List<User> GetAllUsers()
    {
        return [.. userRepository.GetAll()];
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public void SaveUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.PasswordHash))
            throw new ArgumentException("Username and password are required.");

        // Hash solo si es nuevo o cambió
        var existing = userRepository.GetUserById(user.Id);

        if (existing == null)
        {
            user.Id = GenerateNewId();
            user.PasswordHash = HashPassword(user.PasswordHash);
            userRepository.AddUser(user);
        }
        else
        {
            if (user.PasswordHash != existing.PasswordHash)
                user.PasswordHash = HashPassword(user.PasswordHash);

            userRepository.UpdateUser(user);
        }
    }

    public void DeleteUser(int id)
    {
        var current = GetCurrentUser();
        if (current?.Role != Role.Admin)
            throw new UnauthorizedAccessException("Only admins can delete users.");

        userRepository.DeleteUser(id);
    }

    private int GenerateNewId() =>
        userRepository.GetAll().Select(u => u.Id).DefaultIfEmpty(0).Max() + 1;

}
