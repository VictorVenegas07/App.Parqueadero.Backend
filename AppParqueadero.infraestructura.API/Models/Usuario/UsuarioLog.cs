using AppParqueadero.infraestructura.API.Models.Empleado;
using System;

namespace AppParqueadero.infraestructura.API.Models.Usuario
{
    public class UsuarioLog
    {
        public Guid UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Cargo { get; set; }
        public string Token { get; set; }
        public ViewEmpleado Empleado { get; set; }
    }
}
