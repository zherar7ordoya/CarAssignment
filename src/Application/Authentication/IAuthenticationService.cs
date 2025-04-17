using Integrador.Domain.Entities;

namespace Integrador.Application.Authentication;

public interface IAuthenticationService
{
    User? Authenticate(string username, string password);
}
