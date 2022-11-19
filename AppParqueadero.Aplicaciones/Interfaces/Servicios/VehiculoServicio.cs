using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class VehiculoServicio : IServicioBase<Vehiculo, Guid>
    {
        private readonly IRepositorioBase<Vehiculo, Guid> repositorioVehiculo;
        public VehiculoServicio(IRepositorioBase<Vehiculo, Guid> _repositorioVehiculo)
        {
            repositorioVehiculo = _repositorioVehiculo;
        }
        public Vehiculo Agregar(Vehiculo entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException("El vehiculo es requerido");

                var respuestaVehiculo = repositorioVehiculo.Agregar(entidad);
                repositorioVehiculo.GuardarTodosLosCambios();
                return respuestaVehiculo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(Vehiculo entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException("El vehiculo es requerido");

                repositorioVehiculo.Editar(entidad);
                repositorioVehiculo.GuardarTodosLosCambios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            repositorioVehiculo.Eliminar(entidadId);
            repositorioVehiculo.GuardarTodosLosCambios();
        }

        public List<Vehiculo> Listar()
        {
            return repositorioVehiculo.Listar();
        }

        public Vehiculo SeleccionarPorId(Guid entidad)
        {
            return repositorioVehiculo.SeleccionarPorId(entidad);
        }

        public Vehiculo BuscarPlata(string b) {
            return repositorioVehiculo.Consultar(v => v.Placa == b).FirstOrDefault();
        }
    }
}
