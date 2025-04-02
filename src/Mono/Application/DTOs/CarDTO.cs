using System.ComponentModel.DataAnnotations;

namespace Integrador.Application.DTOs;

public record CarDTO(int Id,
                     [Required, StringLength(10, MinimumLength = 6)] string Patente,
                     [Required, StringLength(50)] string Marca,
                     [Required, StringLength(50)] string Modelo,
                     [Range(1886, 2100)] int Año,
                     [Range(0, double.MaxValue)] decimal Precio,
                     int DueñoId);
