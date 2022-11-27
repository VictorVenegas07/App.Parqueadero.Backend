using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppParqueadero.infraestructura.API.Models.Puesto
{
    public class InputPuesto
    {
        [Required(ErrorMessage = "El codigo Puesto es requerido"), MaxLength(4, ErrorMessage = "Codigo Puesto debe tener 4 caracteres o 1 por lo menos "), MinLength(1, ErrorMessage = "Codigo Puesto debe tener 4 caracteres o 1 por lo menos")]
        public String CodigoPuesto { get; set; }
        [Required(ErrorMessage = "El codigo Puesto es requerido"),DisponibilidadValidacion(ErrorMessage ="La disponibilidad debe ser Disponible o ocupado")]
        public String Disponibilidad { get; set; }
    }

    public class DisponibilidadValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object tipo, ValidationContext validationContext)
        {
            if ((tipo.ToString().ToUpper() == "DISPONIBLE") || (tipo.ToString().ToUpper() == "OCUPADO"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
