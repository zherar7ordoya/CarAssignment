using Integrador.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public class JsonUserRepository : IUserRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
    private List<User> _users = [];

    public JsonUserRepository(string filePath)
    {
        _filePath = filePath;
        Load();
    }

    private void Load()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _users = JsonSerializer.Deserialize<List<User>>(json) ?? [];
        }

        if (_users == null)
        {
            _users = Seeder.SeedUsers();
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

    public List<User> GetAll()
    {
        return [.. _users];
    }

    public void Save(User user)
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

    public void Update(User user)
    {
        Save(user);
    }
}

