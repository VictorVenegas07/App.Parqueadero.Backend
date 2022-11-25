using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class ServicioEstadistica : IServicioEstadisticas
    {
        private readonly IEstadisticasRepositorio repositorio;
        public ServicioEstadistica(IEstadisticasRepositorio repositorio_)
        {
            repositorio = repositorio_;
        }
        public Estadistica Productividad()
        {
           var estadisticas = repositorio.Productividad();
            if (estadisticas is null)
                throw new ValidatorDTO("No hay datos");

            return estadisticas;
        }

        public IEnumerable<TotalGeneradoCadaMes> TotalGeneradoCadaMes()
        {
            var total = repositorio.TotalGeneradoCadaMes();
            if (total is null)
                throw new ValidatorDTO("No hay totales");
            return total;
        }

        public IEnumerable<VehiculosMasUsados> VehiculosMasUsados()
        {
            var vehiculos = repositorio.VehiculosMasUsados();
            if (vehiculos is null)
                throw new ValidatorDTO("No hay vehiculos");
            return vehiculos;
        }
    }
}
