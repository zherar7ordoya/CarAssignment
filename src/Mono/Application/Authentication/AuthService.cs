using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

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

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
