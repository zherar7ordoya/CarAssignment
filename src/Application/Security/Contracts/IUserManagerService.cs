﻿using CarAssignment.Application.Security.Core;
using CarAssignment.Domain.Entities;

namespace CarAssignment.Application.Security.Contracts;

public interface IUserManagerService
{
    void CreateUser(string username, string password);
    void DeleteUser(string username);
    void UpdatePassword(string username, string newPassword);
    User? GetUserByUsername(string username);
    List<User> GetAllUsers();
    void SetUserRoles(string username, List<string> roleNames);
    void SetUserSpecialPermissions(string username, List<Permission> permissions);
}

