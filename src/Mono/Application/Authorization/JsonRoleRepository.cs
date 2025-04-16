using System.Configuration;
using System.Text.Json;

namespace Integrador.Application.Authorization;

public class JsonRoleRepository : IRoleRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions; // Cached instance
    private List<Role> _roles = [];

    public JsonRoleRepository()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonRolePath"];
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "Role.json");
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true }; // Initialize once
        Load();
    }

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _roles = JsonSerializer.Deserialize<List<Role>>(json) ?? [];
        }

        if (_roles == null)
        {
            _roles = Seeder.SeedRoles();
            Save();
        }
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_roles, _jsonSerializerOptions); // Reuse cached instance
        File.WriteAllText(_filePath, json);
    }

    public Role? GetByName(string name)
    {
        return _roles.FirstOrDefault(r => r.Name == name);
    }

    public List<Role> GetAll()
    {
        return [.. _roles];
    }

    public void Save(Role role)
    {
        var existing = _roles.FirstOrDefault(r => r.Name == role.Name);
        if (existing != null)
            _roles.Remove(existing);

        _roles.Add(role);
        Save();
    }

    public void Delete(string name)
    {
        var role = _roles.FirstOrDefault(r => r.Name == name);
        if (role != null)
        {
            _roles.Remove(role);
            Save();
        }
    }
}
