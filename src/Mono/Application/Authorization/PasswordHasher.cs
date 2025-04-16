﻿using System.Security.Cryptography;
using System.Text;

namespace Integrador.Application.Authorization;

public static class PasswordHasher
{
    public static string Hash(string plainTextPassword)
    {
        var bytes = Encoding.UTF8.GetBytes(plainTextPassword);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}