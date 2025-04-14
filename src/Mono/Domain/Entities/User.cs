using Integrador.Domain.Enums;

namespace Integrador.Domain.Entities;

public class User : EntityBase
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public Role Role { get; set; }
}
