using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models
{
    public class ReservaModel
    {
        public ClienteModels cliente { get; set; }
        public VehiculoModels Vehiculo { get; set; }
        public Guid PuestoId { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
