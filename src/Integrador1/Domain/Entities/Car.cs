using Integrador.Domain.Exceptions;

namespace Integrador.Domain.Entities;

public class Car : BaseEntity
{
    public Car(string patente, string marca, string modelo, int año, decimal precio)
    {
        // Validación delegada al dominio
        if (string.IsNullOrEmpty(patente))
        {
            throw new DomainException("Patente no puede ser vacía");
        }

        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
    }

    // Propiedades encapsuladas (sin setters públicos)
    public string Patente { get; private set; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public int Año { get; private set; }
    public decimal Precio { get; private set; }

    // Método para actualización segura
    public void Update(string marca, string modelo, decimal precio)
    {
        Marca = marca;
        Modelo = modelo;
        Precio = precio;
    }
}
