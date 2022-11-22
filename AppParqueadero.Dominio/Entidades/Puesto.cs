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
    public class Puesto:EntidadBase
    {
        
            [Key]
            public Guid PuestoId { get; set; }
            [Column(TypeName = "varchar(15)")]
            public String CodigoPuesto { get; set; }
            [Column(TypeName = "varchar(12)")]
            public String Disponibilidad { get; set; }
            [JsonIgnore]
            public List<Reserva> Reservas { get; set; }
            [JsonIgnore]
            public List<Ticket> Tickets { get; set; }
        
        public void Modificar(string disponibilidad_)
        {
            Disponibilidad = disponibilidad_;
        }

    }
}
