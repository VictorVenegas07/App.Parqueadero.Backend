using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using AppParqueadero.infraestructura.API.Models.Cliente;
using System.ComponentModel.DataAnnotations;

namespace AppParqueadero.infraestructura.API.Models.Vehiculo
{
    public class VehiculoModels
    {
        [Required(ErrorMessage = "La placa es requerida"), MaxLength(7, ErrorMessage = "placa debe tener 10 caracteres  por lo menos ")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "La Modelo es requerida"), MaxLength(4, ErrorMessage = "Modelo debe tener 4 caracteres"), MinLength(4, ErrorMessage = "Modelo debe tener 4 caracteres")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "La Marca es requerida"), MaxLength(15, ErrorMessage = "Marca debe tener 15 caracteres o 4 por lo menos "), MinLength(4, ErrorMessage = "Marca debe tener 15 caracteres o 4 por lo menos")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "La Marca es requerida"), TipoValidacion(ErrorMessage ="Tipo de vehiculo debe ser Auto o moto")]
        public string Tipo { get; set; }
    }

    public class VehiculoInput:VehiculoModels 
    {
        public Guid ClienteId { get; set; }
    }

    public class TipoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object tipo, ValidationContext validationContext)
        {
            if ((tipo.ToString().ToUpper() == "AUTO") || (tipo.ToString().ToUpper() == "MOTO"))
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
