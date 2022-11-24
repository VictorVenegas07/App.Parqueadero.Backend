using AppParqueadero.infraestructura.API.Models.Cliente;
using AppParqueadero.infraestructura.API.Models.Puesto;
using AppParqueadero.infraestructura.API.Models.Vehiculo;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppParqueadero.infraestructura.API.Models.Reserva
{
    public class ViewReserva
    {
        public Guid ReservaId { get; set; }
        public ViewCliente cliente { get; set; }
        public ViewVehiculo Vehiculo { get; set; }
        public ViewPuesto Puesto { get; set; }
        public DateTime FechaHora { get; set; }
        public String Estado { get; set; }

    }
}
