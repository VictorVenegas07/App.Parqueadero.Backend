using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Cliente;
using AppParqueadero.infraestructura.API.Models.Usuario;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AppParqueadero.infraestructura.API.Models.Empleado
{
    public class EmpleadoInput: ClienteModels
    {
        [
            EmailValidacion(ErrorMessage ="El correo debe contener alguno de esto @-.co-.com"),
            MaxLength(25, ErrorMessage = "correo debe tener 25 caracteres o 10 por lo menos"), 
            MinLength(10, ErrorMessage = "correo debe tener 10 caracteres o 10 por lo menos")
        ]
        public string Email { get; set; }
        public UsuarioInput Usuario { get; set; }

    }

    public class EmailValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object email, ValidationContext validationContext)
        {
            var expresion = @"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (Regex.IsMatch(email.ToString(), expresion))
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
