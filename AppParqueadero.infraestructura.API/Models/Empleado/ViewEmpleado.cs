using System;

namespace AppParqueadero.infraestructura.API.Models.Empleado
{
    public class ViewEmpleado
    {
        public Guid EmpleadoId { get; set; }
        public string Identificacion { get; set; }
        public string TipoDocumuento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
