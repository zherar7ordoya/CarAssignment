using System.Text.Json.Serialization;

namespace Integrador.Application.Authorization;

[method: JsonConstructor]
public class Role(string name, List<Permission> permissions)
{
    public string Name { get; } = name;
    public List<Permission> Permissions { get; } = permissions;
}


