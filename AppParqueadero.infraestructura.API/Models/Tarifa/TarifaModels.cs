using System.ComponentModel.DataAnnotations;

namespace AppParqueadero.infraestructura.API.Models.Tarifa
{
    public class TarifaModels
    {
        [Required(ErrorMessage = "La Tipo de tarifa es requerido"), MaxLength(10, ErrorMessage = "Tipo de tarifa debe tener 4 caracteres"), MinLength(4, ErrorMessage = "Tipo de tarifa debe tener 4 caracteres")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El Valor es requerido"), MaxLength(4, ErrorMessage = "Valor debe tener 4 caracteres"), MinLength(5, ErrorMessage = "Valor debe tener 4 caracteres")]

        public decimal Valor { get; set; }
    }
}
