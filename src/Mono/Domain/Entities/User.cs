using Integrador.Application.Authorization;
using Integrador.Domain.Enums.Authorization;

namespace Integrador.Domain.Entities;

public class User : EntityBase
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;

    // Referencias a los nombres de roles, que luego se resuelven
    public List<string> RoleNames { get; set; } = new();

    // Permisos especiales fuera de rol
    public List<Permission> SpecialPermissions { get; set; } = new();
}
