using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Configs
{
    public static class DataSeed
    {
        public static List<Puesto> puestos { get; set; }
        public static List<Tarifa> tarifas { get; set; }

        public static List<Puesto> DataPuestos()
        {
            puestos = new List<Puesto>();
            for (int i = 0; i < 10; i++)
            {
                puestos.Add(new Puesto() { PuestoId = Guid.NewGuid(), CodigoPuesto = $"A{i}", Disponibilidad = "Disponible" });
            }
            return puestos;
        }

        public static  List<Tarifa> DataTarifas()
        {
            tarifas = new List<Tarifa>();
            tarifas.Add(new Tarifa() { TarifaId = Guid.NewGuid(), Valor = 3000, Tipo = "Auto" });
            tarifas.Add(new Tarifa() { TarifaId = Guid.NewGuid(), Valor = 1000, Tipo = "Moto" });
            return tarifas;
        }
    }
}
