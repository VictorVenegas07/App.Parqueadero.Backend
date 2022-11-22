using AppParqueadero.Dominio.Entidades;
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
    public class Vehiculo
    {

        [Key]
        public Guid VehiculoId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public String Placa { get; set; }
        [Column(TypeName = "varchar(20)")]
        public String Modelo { get; set; }
        [Column(TypeName = "varchar(25)")]
        public String Marca { get; set; }
        [Column(TypeName = "varchar(20)")]
        public String Tipo { get; set; }
        public Guid ClienteId { get; set; }
        [JsonIgnore]
        public Cliente cliente { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }
    }
}
