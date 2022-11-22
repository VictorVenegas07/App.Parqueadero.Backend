using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using AppParqueadero.Aplicaciones.Interfaces;
using AppParqueadero.Aplicaciones.Excepciones;

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
            if (ValidarVehiculo(entidad))
                throw new ValidarExceptions($"El vehiculo con placa {entidad.Placa} ya existe");

            var respuesta= repositorioVehiculo.Agregar(entidad);
            repositorioVehiculo.GuardarTodosLosCambios();
            return respuesta;
        }
        private bool ValidarVehiculo(Vehiculo entidad)
        {
            var vehiculo = repositorioVehiculo.Consultar(x => x.Placa == entidad.Placa).FirstOrDefault();
            return vehiculo is not null;
        }

        public void Editar(Vehiculo entidad, Guid id)
        {
            var response = repositorioVehiculo.SeleccionarPorId(id);
            if (response is null)
                throw new ValidarExceptions($"El vehiculo con placa {entidad.Placa} no exite");
           
            repositorioVehiculo.Editar(response, id);
            repositorioVehiculo.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            var response = repositorioVehiculo.SeleccionarPorId(entidadId);
            if (response is not null)
                repositorioVehiculo.Eliminar(entidadId);
            else
                throw new ValidarExceptions($"el cliente que desea eliminar no existe");

            repositorioVehiculo.GuardarTodosLosCambios();
        }

        public List<Vehiculo> Listar()
        {
            return repositorioVehiculo.Listar();
        }

        public Vehiculo SeleccionarPorId(Guid entidad)
        {
            var res = repositorioVehiculo.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"el vehiculo que busca no existe");

            return res;
        }

        public Vehiculo BuscarPlata(string b) {
            return repositorioVehiculo.Consultar(v => v.Placa == b).FirstOrDefault();
        }
    }
}
