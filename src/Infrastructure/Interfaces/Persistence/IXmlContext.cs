﻿using Integrador.Domain.Contracts;

namespace Integrador.Infrastructure.Interfaces.Persistence;

public interface IXmlContext<T> where T : IEntity
{
    List<T> Read();
    void Write(List<T> data);
}