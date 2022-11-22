using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models.Cliente
{
    public class ClienteModels
    {
        public string Identificacion { get; set; }
        public string TipoDocumuento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
