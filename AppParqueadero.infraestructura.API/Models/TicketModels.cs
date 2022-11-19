using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models
{
    public class TicketModels
    {
        public Guid TarifaId { get; set; }
        public Guid PuestoId { get; set; }
        public Guid EmpleadoId { get; set; }
        public string Estado { get; set; }
        public DateTime HoraDeEntrada { get; set; }
        public ClienteModels Cliente { get; set; }
        public VehiculoModels Vehiculo { get; set; }
    }
}
