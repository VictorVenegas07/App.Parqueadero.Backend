using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AppParqueadero.infraestructura.API.Models.Vehiculo
{
    public class ViewVehiculo
    {
        public Guid VehiculoId { get; set; }
        public String Placa { get; set; }
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String Tipo { get; set; }
    }
}
