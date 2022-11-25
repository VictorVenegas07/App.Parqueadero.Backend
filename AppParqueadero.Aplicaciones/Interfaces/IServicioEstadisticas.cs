using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface IServicioEstadisticas
    {
        Estadistica Productividad();
        IEnumerable<TotalGeneradoCadaMes> TotalGeneradoCadaMes();
        IEnumerable<VehiculosMasUsados> VehiculosMasUsados();
    }
}
