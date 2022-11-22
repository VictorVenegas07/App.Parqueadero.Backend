using System;

namespace AppParqueadero.infraestructura.API.Models.Tarifa
{
    public class ViewTarifa
    {
        public Guid TarifaId { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
