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
    public class Cliente
    {

        [Key]
        public Guid ClienteId { get; set; }
        [Column(TypeName = "varchar(11)")]
        public String Identificacion { get; set; }
        [Column(TypeName = "varchar(3)")]
        public String TipoDocumuento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public String Nombre { get; set; }
        [Column(TypeName = "varchar(15)")]
        public String Telefono { get; set; }
        [JsonIgnore]
        public List<Vehiculo> Vehiculos { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
    }
}
