namespace Integrador.Application.DTOs;

public record PersonDTO(int Id,
                        string DNI,
                        string Nombre,
                        string Apellido,
                        List<CarDTO> Autos)
{
    // Los DTOs suelen usarse solo como contenedores de datos sin lógica de negocio.
    // Sin embargo, dado que estos métodos (GetCantidadAutos() y GetValorAutos())
    // solo procesan datos que ya están en el DTO sin realizar lógica compleja ni
    // acceder a dependencias externas, no hay problema en incluirlos.
    public int CantidadAutos => Autos.Count;
    public decimal ValorAutos => Autos.Sum(auto => auto.Precio);
};
