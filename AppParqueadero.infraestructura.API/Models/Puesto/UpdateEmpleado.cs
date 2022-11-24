using AppParqueadero.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models.Puesto
{
    public class UpdateEmpleado
    {
        public String TipoDocumuento { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public string Email { get; set; }

    }
}
