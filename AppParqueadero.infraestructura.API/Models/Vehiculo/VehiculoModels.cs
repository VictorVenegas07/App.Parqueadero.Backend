using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using AppParqueadero.infraestructura.API.Models.Cliente;

namespace AppParqueadero.infraestructura.API.Models.Vehiculo
{
    public class VehiculoModels
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
    }

    public class VehiculoInput:VehiculoModels 
    {
        public Guid ClienteId { get; set; }
    }
}
