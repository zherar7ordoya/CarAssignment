﻿using System.Configuration;
using LiteDB;
using CarAssignment.Infrastructure.Interfaces.Persistence;
using CarAssignment.Domain.Contracts;

namespace CarAssignment.Infrastructure.Persistence.LiteDB.Context;

public class LiteDbContext<T>() : ILiteDbContext<T> where T : IEntity
{
    private static readonly string _connectionString = GetConnectionString();
    private static readonly string _databasePath = GetDatabasePath();
    public string CollectionName => typeof(T).Name;

    public LiteDatabase GetDatabase()
    {
        EnsureFileExists();
        return new LiteDatabase(_connectionString);
    }

    /* ////////////////////////////////////////////////////////////////////// */

    private static string GetConnectionString()
    {
        var config = ConfigurationManager.ConnectionStrings["LiteDbBusinessConnection"];
        return config == null
            ? throw new InvalidOperationException("LiteDB connection string not found.")
            : config.ConnectionString;
    }

    private static string GetDatabasePath()
    {
        // Para asegurarnos que el archivo esté en el path correcto
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionString);
    }

    private static void EnsureFileExists()
    {
        var fullPath = GetDatabasePath();
        if (!File.Exists(fullPath))
        {
            using var db = new LiteDatabase(fullPath);
            db.Checkpoint();
        }
    }
}
