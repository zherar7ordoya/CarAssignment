using Integrador.Application.Interfaces;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authentication;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private User? _currentUser;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Login(string username, string password)
    {
        var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username);
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
