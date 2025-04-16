using Integrador.Domain.Entities;


namespace Integrador.Application.Authorization;

public class User : EntityBase
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;

    public List<string> RoleNames { get; set; } = [];
    public List<Permission> SpecialPermissions { get; set; } = [];
}
