using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class EstadisticaRepositori : IEstadisticasRepositorio
    {
        ParqueaderoContexto contexto;
        public EstadisticaRepositori(ParqueaderoContexto contexto_)
        {
            contexto = contexto_;
        }
        public Estadistica Productividad()
        {
            return contexto.Estadisticas.FromSqlRaw("SELECT " +
                "SUM(Total) AS [TotalProducido]," +
                "COUNT(*) AS [Cantidad],SUM(DATEPART(HOUR, HoraDeSalida)-DATEPART(HOUR,HoraDeEntrada )) AS [HorasServicio]," +
                "ISNULL((SELECT SUM(total) from Ticked WHERE  MONTH(HoraDeEntrada) =  MONTH(GETDATE())-1),0) AS [ProducidoAnterior]," +
                "ISNULL((SELECT SUM(DATEPART(HOUR,HoraDeEntrada )-DATEPART(HOUR, HoraDeSalida))  from Ticked WHERE  MONTH(HoraDeEntrada) =  MONTH(GETDATE())-1),0) AS [HorasServicioAnterior]" +
                "from Ticked WHERE MONTH(HoraDeEntrada) = MONTH(GETDATE()) and estado ='Salida' GROUP BY MONTH(HoraDeEntrada)")
                .ToList()
                .FirstOrDefault();
        }

        public IEnumerable<TotalGeneradoCadaMes> TotalGeneradoCadaMes()
        {
            return contexto.TotalGenerados.FromSqlRaw("SELECT" +
                " COUNT(*) AS Cantidad," +
                " SUM(Total)AS Total,MONTH(HoraDeEntrada) AS Mes" +
                " FROM Ticked WHERE Year(HoraDeEntrada) = Year(GetDate()) GROUP BY MONTH(HoraDeEntrada)")
                .ToList();
        }

        public IEnumerable<VehiculosMasUsados> VehiculosMasUsados()
        {
            return contexto.vehiculosMasUsados.FromSqlRaw("Select " +
                "tipo AS [Tipo] ," +
                " COUNT(*) AS [Cantidad] " +
                "FROM Vehiculo GROUP BY TIPO")
                .ToList();
        }
    }
}
