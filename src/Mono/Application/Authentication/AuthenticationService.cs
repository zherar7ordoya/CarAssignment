using Integrador.Application.Authorization;

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
