using Integrador.Application.Security.Contracts;
using Integrador.Application.Security.Core;
using Integrador.Infrastructure.Persistence.Seeding;

using System.Configuration;
using System.Text.Json;

namespace Integrador.Infrastructure.Persistence.JSON;

public class JsonRoleRepository : IRoleRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
    private List<Role> _roles = [];

    public JsonRoleRepository()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonRolePath"];
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "Role.json");
        EnsureFolderExists();
        Load();
    }

    private void EnsureFolderExists()
    {
        var folderPath = Path.GetDirectoryName(_filePath);

        if (folderPath != null && !Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _roles = JsonSerializer.Deserialize<List<Role>>(json) ?? [];
        }

        if (_roles.Count == 0)
        {
            _roles = SecuritySeeder.SeedRoles();
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
