using System.ComponentModel.DataAnnotations;

namespace Integrador.Application.DTOs;

public record CarDTO(int Id,
                     [Required, StringLength(10, MinimumLength = 6)] string LicensePlate,
                     [Required, StringLength(50)] string Brand,
                     [Required, StringLength(50)] string Model,
                     [Range(1886, 2100)] int Year,
                     [Range(0, double.MaxValue)] decimal Price,
                     int PersonId);
