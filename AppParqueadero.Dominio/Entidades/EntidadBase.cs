using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class EntidadBase
    {
        public String usuarioCrea { get; set; }
        public DateTime FechaCreacion { get; }
        public String usuarioModifica { get; set; }
        public DateTime ?FechaModifica { get; set; }
    }
}
