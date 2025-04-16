using System.Security.Cryptography;
using System.Text;

namespace Integrador.Application.Authorization;

public static class Seeder
{
    public static List<Role> SeedRoles()
    {
        return
        [
            new("Admin",
            [
                new Permission("CreateEntity"),
                new Permission("EditEntity"),
                new Permission("DeleteEntity"),
                new Permission("ManageUsers"),
                new Permission("ManageRoles")
            ]),
            new("User",
            [
                new Permission("CreateEntity"),
                new Permission("EditEntity")
            ])
        ];
    }

    public static List<User> SeedUsers()
    {
        return
        [
            new() {
                Username = "admin",
                PasswordHash = Hash("admin"), // Simple hash for seed/demo purposes
                RoleNames = ["Admin"],
                SpecialPermissions = []
            },
            new() {
                Username = "user",
                PasswordHash = Hash("user"),
                RoleNames = ["User"],
                SpecialPermissions = []
            }
        ];
    }

    private static string Hash(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}

