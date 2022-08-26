using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio
{
    public class Reserva
    {

        [Key]
        [Column(TypeName = "int")]
        public Guid  ReservaId { get; set; }


        [Column(TypeName = "varchar(15)")]
        public Guid ClienteId { get; set; }


        [JsonIgnore]
        public Cliente Cliente { get; set; }


        [Column(TypeName = "varchar(10)")]
        public Guid VehiculoId { get; set; }


        [JsonIgnore]
        public Vehiculo Vehiculo { get; set; }


        [Column(TypeName = "int")]
        public Guid PuestoId { get; set; }


        [JsonIgnore]
        public Puesto Puesto { get; set; }


        [Column(TypeName = "DateTime")]
        public DateTime FechaHora { get; set; }


        [Column(TypeName = "varchar(11)")]
        public String Estado { get; set; }

    }
}
