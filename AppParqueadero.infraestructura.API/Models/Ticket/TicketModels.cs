using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using AppParqueadero.infraestructura.API.Models.Vehiculo;
using AppParqueadero.infraestructura.API.Models.Cliente;


namespace AppParqueadero.infraestructura.API.Models.Ticket
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
