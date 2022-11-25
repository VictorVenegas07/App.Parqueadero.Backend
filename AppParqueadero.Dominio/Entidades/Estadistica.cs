using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Estadistica
    {
        [Key]
        public int Cantidad { get; set; }
        public decimal TotalProducido { get; set; }
        public int HorasServicio { get; set; }
        public decimal ProducidoAnterior { get; set; }
        public int? HorasServicioAnterior { get; set; }
        [NotMapped]
        public decimal Crecimiento { get => (ProducidoAnterior > 0) ? Math.Round((TotalProducido - ProducidoAnterior) / ProducidoAnterior, 2) : 0; }
    }

    public class TotalGeneradoCadaMes
    {
        [Key]
        public int? Mes { get; set; }
        public int? Cantidad { get; set; }
        public decimal Total { get; set; }

    }

    public class VehiculosMasUsados
    {
        [Key]
        public string? Tipo { get; set; }
        public int? Cantidad { get; set; }

    }
}
