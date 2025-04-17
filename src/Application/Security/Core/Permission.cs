namespace Integrador.Application.Security.Core;

public class Permission(string name)
{
    public string Name { get; } = name;

    public override bool Equals(object? obj) =>
        obj is Permission other && Name == other.Name;

    public override int GetHashCode() => Name.GetHashCode();

    public override string ToString() => Name;
}
