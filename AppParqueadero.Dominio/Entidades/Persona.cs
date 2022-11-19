using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Persona:EntidadBase
    {
        public String Identificacion { get; set; }
        [Column(TypeName = "varchar(3)")]
        public String TipoDocumuento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public String Nombre { get; set; }
        [Column(TypeName = "varchar(15)")]
        public String Telefono { get; set; }
    }
}
