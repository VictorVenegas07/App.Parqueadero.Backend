using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Tarifa:EntidadBase
    {
        public Guid TarifaId { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }

        public void Actualizar(decimal valor_)
        {
            Valor = valor_;
           
        }
    }
}
