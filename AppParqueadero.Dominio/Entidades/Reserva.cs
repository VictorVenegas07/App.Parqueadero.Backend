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
        public Guid  ReservaId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VehiculoId { get; set; }
        public Guid PuestoId { get; set; }
        [JsonIgnore]
        public Cliente cliente { get; set; }
        [JsonIgnore]
        public Vehiculo Vehiculo { get; set; }
        [JsonIgnore]
        public Puesto Puesto { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime FechaHora { get; set; }
        [JsonIgnore]
        [Column(TypeName = "varchar(11)")]
        public String Estado { get; set; }

        public void Modificar(string estado)
        {
            Estado = estado;
        }

    }
}
