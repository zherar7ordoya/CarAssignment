using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Integrador.Domain.Entities;
using System.Configuration;
using Integrador.Domain.Enums;
using System.Security.Cryptography;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Authentication;

public class JsonUserRepository : IUserRepository
{
    private readonly string _filePath;
    private List<User> _users = [];

    public JsonUserRepository()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonUserPath"];
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "User.json");
        EnsureFolderExists();
        LoadUsers();
        SeedDefaultUsers();
    }

    private void EnsureFolderExists()
    {
        var folderPath = Path.GetDirectoryName(_filePath);

        if (folderPath != null && !Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public User? GetByUsername(string username)
    {
        return _users.FirstOrDefault(user => user.Username?.Equals(username, StringComparison.OrdinalIgnoreCase) == true);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    private void LoadUsers()
    {
        if (!File.Exists(_filePath))
        {
            _users = [];
            return;
        }

        var json = File.ReadAllText(_filePath);
        _users = JsonSerializer.Deserialize<List<User>>(json, _jsonSerializerOptions) ?? [];
    }

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_users, _jsonSerializerOptions);
        File.WriteAllText(_filePath, json);
    }

    private void SeedDefaultUsers()
    {
        if (_users.Count != 0) return;

        var defaultAdmin = new User
        {
            Id = 1,
            Username = "admin",
            PasswordHash = HashPassword("admin"), // Podemos cambiar la política de seguridad luego
            Role = Role.Admin
        };

        _users.Add(defaultAdmin);

        var defaultUser = new User
        {
            Id = 2,
            Username = "user",
            PasswordHash = HashPassword("user"), // Podemos cambiar la política de seguridad luego
            Role = Role.User
        };

        _users.Add(defaultUser);

        SaveChanges();
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}
