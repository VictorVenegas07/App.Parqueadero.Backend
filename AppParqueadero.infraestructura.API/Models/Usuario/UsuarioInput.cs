using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppParqueadero.infraestructura.API.Models.Usuario
{
    public class UsuarioInput
    {
        [Required(ErrorMessage = "El Nombre Usuario es requerido"),MaxLength(15, ErrorMessage = "Nombre Usuario debe tener 15 caracteres o 5 por lo menos "), MinLength(5, ErrorMessage = "Nombre Usuario debe tener 15 caracteres o 5 por lo menos")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage ="La contraseña es requerida"),ContraseñaValidacion(ErrorMessage ="La contraseña debe ser alfa numerica"), MaxLength(15, ErrorMessage = "contraseña debe tener 15 caracteres o 8 por lo menos "),MinLength(8, ErrorMessage = "contraseña debe tener 15 caracteres o 8 por lo menos")]
        public string Contraseña { get; set; }
        [ Required(ErrorMessage = "El cargo es requerido"),CargoValidacion(ErrorMessage = "El cargo debe ser empleado o administrador")]
        public string Cargo { get; set; }
    }

    public class ContraseñaValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object password, ValidationContext validationContext)
        {
            var expresion = "/[A-Za-z0-9_]/";
            
            if (password.ToString().All(char.IsLetterOrDigit))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
    public class CargoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object tipo, ValidationContext validationContext)
        {
            if ((tipo.ToString().ToUpper() == "EMPLEADO") || (tipo.ToString().ToUpper() == "ADMINISTRADOR"))
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
