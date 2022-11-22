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
    public class Cliente:Persona
    {

        [Key]
        public Guid ClienteId { get; set; }
      
        [JsonIgnore]
        public List<Vehiculo> Vehiculos { get; set; }
        [JsonIgnore]
        public List<Reserva> Reservas { get; set; }
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }

        public void Modificar(string tipoDocumento, string nombre, string telefono)
        {
            TipoDocumuento = tipoDocumento;
            Nombre = nombre;
            Telefono = telefono;
        }

    }
}
