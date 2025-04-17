using Integrador.Application.Security.Contracts;
using Integrador.Application.Security.Services;
using Integrador.Domain.Entities;

namespace Integrador.Application.Authentication;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public User? Authenticate(string username, string password)
    {
        var user = userRepository.GetByUsername(username);
        if (user == null) return null;

        string hash = PasswordHasher.Hash(password); // o usar algún helper externo
        return user.PasswordHash == hash ? user : null;
    }

}
