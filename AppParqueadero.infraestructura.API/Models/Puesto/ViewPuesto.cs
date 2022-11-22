using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models.Puesto
{
    public class ViewPuesto
    {
        public Guid PuestoId { get; set; }
        public String CodigoPuesto { get; set; }
        public String Disponibilidad { get; set; }
    }
}
