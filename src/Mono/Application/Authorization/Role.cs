namespace Integrador.Application.Authorization;

public class Role(string name, IEnumerable<Permission> permissions)
{
    public string Name { get; } = name;
    public List<Permission> Permissions { get; } = [.. permissions];
}
