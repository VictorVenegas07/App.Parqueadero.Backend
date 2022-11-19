using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Horario : EntidadBase
    {
        public Guid HorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public Guid EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
