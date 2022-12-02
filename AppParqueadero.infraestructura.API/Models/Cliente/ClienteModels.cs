using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppParqueadero.infraestructura.API.Models.Cliente
{
    public class ClienteModels
    {
        [Required(ErrorMessage = "La Identificacion es requerida"), MaxLength(10, ErrorMessage = "Identificacion debe tener 10 caracteres o 6 por lo menos "), MinLength(6, ErrorMessage = "Identificacion debe tener 10 caracteres o 6 por lo menos")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "El tipo de documento es requeido"), TipoDocumentoValidacion(ErrorMessage ="Tipo documento no es valido")]
        public string TipoDocumuento { get; set; }
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(15, ErrorMessage = "Nombre debe tener 15 caracteres o 5 por lo menos"), MinLength(5, ErrorMessage = "Nombre debe tener 15 caracteres o 5 por lo menos")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El telefono es requerido"), MaxLength(10, ErrorMessage = "Telefono debe tener 10 caracteres o 8 por lo menos"), MinLength(8, ErrorMessage = "Telefono debe tener 10 caracteres o 8 por lo menos")]
        public string Telefono { get; set; }
    }

    public class TipoDocumentoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object tipo, ValidationContext validationContext)
        {
            if ((tipo.ToString().ToUpper() == "CC") || (tipo.ToString().ToUpper() == "TI") || (tipo.ToString().ToUpper() == "CE"))
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
