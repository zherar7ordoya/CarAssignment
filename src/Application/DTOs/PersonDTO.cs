using System.ComponentModel.DataAnnotations;

namespace Integrador.Application.DTOs;

public record PersonDTO(int Id,
                        [Required, RegularExpression("^\\d{7,8}$", ErrorMessage = "Identity number must have between 7 and 8 digits.")] string IdentityNumber,
                        [Required, StringLength(50)] string FirstName,
                        [Required, StringLength(50)] string LastName,
                        List<CarDTO> CarIds)
{
    // Los DTOs suelen usarse solo como contenedores de datos sin lógica de negocio.
    // Sin embargo, dado que estos métodos (GetCantidadAutos() y GetValorAutos())
    // solo procesan datos que ya están en el DTO sin realizar lógica compleja ni
    // acceder a dependencias externas, no hay problema en incluirlos.
    public int GetCarsCount => CarIds.Count;
    public decimal GetCarsPrice => CarIds.Sum(car => car.Price);
};
