using Integrador.Application.Authorization;

namespace Integrador.Application.Authentication;

public interface IAuthenticationService
{
    User? Authenticate(string username, string password);
}
