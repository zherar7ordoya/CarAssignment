using CarAssignment.Application.Security.Contracts;
using CarAssignment.Domain.Entities;
using CarAssignment.Infrastructure.Persistence.Seeding;

using System.Configuration;
using System.Text.Json;

namespace CarAssignment.Infrastructure.Persistence.JSON;

public class JsonUserRepository : IUserRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
    private List<User> _users = [];

    public JsonUserRepository()
    {
        var pathFromConfig = ConfigurationManager.AppSettings["JsonUserPath"];
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathFromConfig ?? "User.json");
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
            _users = JsonSerializer.Deserialize<List<User>>(json) ?? [];
        }

        if (_users.Count == 0)
        {
            _users = SecuritySeeder.SeedUsers();
            Save();
        }
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_users, _jsonSerializerOptions);
        File.WriteAllText(_filePath, json);
    }

    public User? GetByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }

    public List<User> ReadAll()
    {
        return [.. _users];
    }

    public void Update(User user)
    {
        var existing = _users.FirstOrDefault(u => u.Username == user.Username);
        if (existing != null)
            _users.Remove(existing);

        _users.Add(user);
        Save();
    }

    public void Delete(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            _users.Remove(user);
            Save();
        }
    }

    public void Create(User user)
    {
        if (_users.Any(u => u.Username == user.Username))
            throw new InvalidOperationException("User already exists.");
        _users.Add(user);
        Save();
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    
}

