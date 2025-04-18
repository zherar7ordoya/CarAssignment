using Integrador.Application.Security.Core;
using Integrador.Application.Security.Services;
using Integrador.Domain.Entities;

using System.Security.Cryptography;
using System.Text;

namespace Integrador.Infrastructure.Persistence.Seeding;

public static class SecuritySeeder
{
    public static List<Role> SeedRoles()
    {
        return
        [
            new("Admin",
            [
                new("NewPerson"),
                new("SavePerson"),
                new("DeletePerson"),
                new("NewCar"),
                new("SaveCar"),
                new("DeleteCar"),
                new("AssignCar"),
                new("RemoveCar"),
                new("LogViewer"),
                new("UserManagement"),
                new("RoleManagement")
            ]),
            new("User",
            [
                new("NewPerson"),
                new("SavePerson"),
                new("NewCar"),
                new("SaveCar"),
                new("AssignCar"),
                new("RemoveCar"),
                new("LogViewer")
            ])
        ];
    }

    public static List<User> SeedUsers()
    {
        return
        [
            new()
            {
                Username = "admin",
                PasswordHash = PasswordHasher.Hash("admin"),
                RoleNames = ["Admin"],
                SpecialPermissions = [] // sin permisos duplicados
            },
            new()
            {
                Username = "user",
                PasswordHash = PasswordHasher.Hash("user"),
                RoleNames = ["User"],
                SpecialPermissions = []
            }
        ];
    }
}
