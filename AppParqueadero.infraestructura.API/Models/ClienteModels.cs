using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models
{
    public class ClienteModels
    {
        public String Identificacion { get; set; }
        public String TipoDocumuento { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
    }
}
