using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Usuario:EntidadBase
    {
        public Guid UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Cargo { get; set; }
        public Guid EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
