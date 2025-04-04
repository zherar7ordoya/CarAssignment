﻿using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    void Create(T entity);
    List<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Delete(int id);
}
