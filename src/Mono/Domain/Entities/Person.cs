﻿using Integrador.Domain.Exceptions;
using Integrador.Shared.Interfaces;

namespace Integrador.Domain.Entities;

public class Person : BaseEntity, IPerson
{
    // Empty constructor required by serialization.
    public Person() { }
    public Person(string dni,
                  string nombre,
                  string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }

    // Public setters required for serialization.
    // Default values required by empty constructor.
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public List<Car> Autos { get; set; } = [];

    public bool HasCars() => Autos.Count > 0;

    public bool OwnsCar(Car car)
    {
        var ownedCar = Autos.FirstOrDefault(c => c.Id == car.Id);
        return ownedCar != null;
    }

    public void AssignCar(Car car)
    {
        Autos.Add(car);
    }

    public void RemoveCar(Car car)
    {
        var carToRemove = Autos.FirstOrDefault(c => c.Id == car.Id);

        if (carToRemove == null)
        {
            throw new DomainException("El auto no pertenece a la persona.");
        }
        else
        {
            Autos.Remove(carToRemove);
        }
    }

    ////////////////////////////////////////////////////////////////////////////

    public List<Car> GetListaAutos() => Autos;
    public int GetCantidadAutos() => Autos.Count;
    public decimal GetValorAutos() => Autos.Sum(auto => auto.Precio);
    public string GetApellidoNombre() => $"{Apellido}, {Nombre}";
    public string GetDNI() => DNI;
}
