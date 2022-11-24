using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Ticket:EntidadBase
    {
        [Key]
        public Guid TickedId { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Guid TarifaId { get; set; }
        public Tarifa Tarifa { get; set; }
        public Guid PuestoId { get; set; }
        public Puesto Puesto { get; set; }
        public Guid EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public string Estado { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime HoraDeEntrada { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime ?HoraDeSalida { get; set; }
        [Column(TypeName = "Decimal")]
        public Decimal Total { get; set; }

        public void CalcularTotal()
        {
            Total = (decimal)(Math.Abs(HoraDeEntrada.Hour - HoraDeSalida.Value.Hour) * Tarifa.Valor);
        }
        public void Actualizar(string estado)
        {
            Estado = estado;
            HoraDeSalida = DateTime.Now;
        }

        public void AsingarValores()
        {
            Estado = "Entrada";
            HoraDeEntrada = DateTime.Now;
        }
    }
}
