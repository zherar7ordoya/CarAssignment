using CarAssignment.Domain.Entities;

namespace CarAssignment.Application.Authentication;

public interface IAuthenticationService
{
    User? Authenticate(string username, string password);
}
