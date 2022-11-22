using AppParqueadero.infraestructura.API.Models.Cliente;
using AppParqueadero.infraestructura.API.Models.Empleado;
using AppParqueadero.infraestructura.API.Models.Puesto;
using AppParqueadero.infraestructura.API.Models.Tarifa;
using AppParqueadero.infraestructura.API.Models.Vehiculo;
using System;

namespace AppParqueadero.infraestructura.API.Models.Ticket
{
    public class ViewTicketd
    {
        public Guid TickedId { get; set; }
        public string Estado { get; set; }
        public DateTime HoraDeEntrada { get; set; }
        public DateTime HoraDeSalida { get; set; }
        public TarifaModels Tarifa { get; set; }
        public ViewCliente Cliente { get; set; }
        public ViewVehiculo Vehiculo { get; set; }
        public ViewPuesto Puesto { get; set; }
        public Decimal Total { get; set; }


    }
}
