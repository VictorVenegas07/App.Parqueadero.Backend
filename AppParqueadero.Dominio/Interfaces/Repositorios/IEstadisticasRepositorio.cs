using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Interfaces.Repositorios
{
    public interface IEstadisticasRepositorio
    {
        Estadistica Productividad();
        IEnumerable<TotalGeneradoCadaMes> TotalGeneradoCadaMes();
        IEnumerable<VehiculosMasUsados> VehiculosMasUsados();

    }
}
