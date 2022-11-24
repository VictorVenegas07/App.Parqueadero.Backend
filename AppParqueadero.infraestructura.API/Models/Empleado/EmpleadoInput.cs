using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Usuario;

namespace AppParqueadero.infraestructura.API.Models.Empleado
{
    public class EmpleadoInput:Persona
    {
        public string Email { get; set; }
        public UsuarioInput Usuario { get; set; }

    }
}
