using Integrador.Domain.Entities;
using Integrador.Domain.Enums.Authorization;

namespace Integrador.Application.Authorization;

public class User : EntityBase
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;

    // Referencias a los nombres de roles, que luego se resuelven
    public List<string> RoleNames { get; set; } = [];

    // Permisos especiales fuera de rol
    public List<Permission> SpecialPermissions { get; set; } = [];
}
