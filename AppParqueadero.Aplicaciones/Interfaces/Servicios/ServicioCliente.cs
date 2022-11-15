using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class ServicioCliente : IServicioBase<Cliente, Guid>
    {
        private readonly IRepositorioBase<Cliente, Guid> repositorioCliente;
        public ServicioCliente(IRepositorioBase<Cliente, Guid> _repositorioCliente)
        {
            repositorioCliente = _repositorioCliente;
        }

        public Cliente Agregar(Cliente entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException("El Cliente es requerido");

                var respuestaCliente = repositorioCliente.Agregar(entidad);
                repositorioCliente.GuardarTodosLosCambios();
                return respuestaCliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(Cliente entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException("El vehiculo es requerido");

                repositorioCliente.Editar(entidad);
                repositorioCliente.GuardarTodosLosCambios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar(Guid entidad)
        {
            repositorioCliente.Eliminar(entidad);
            repositorioCliente.GuardarTodosLosCambios();
        }

        public List<Cliente> Listar()
        {
            return repositorioCliente.Listar();
        }

        public Cliente SeleccionarPorId(Guid entidad)
        {
            return repositorioCliente.SeleccionarPorId(entidad);
        }
    }
}
