using System;

namespace AppParqueadero.infraestructura.API.Models.Cliente
{
    public class ViewCliente
    {
        public Guid ClienteId { get; set; }
        public string Identificacion { get; set; }
        public string TipoDocumuento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
