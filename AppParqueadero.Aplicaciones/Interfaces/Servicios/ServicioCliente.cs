using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
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
            
                if (ValidarCliente(entidad))
                    throw new ValidarExceptions($"El Cliente con identificacion {entidad.Identificacion} ya existe");

                var respuestaCliente = repositorioCliente.Agregar(entidad);
                repositorioCliente.GuardarTodosLosCambios();
                return respuestaCliente;
           
        }
        private bool ValidarCliente(Cliente entidad)
        {
            var cliente = repositorioCliente.Consultar(x => x.Identificacion == entidad.Identificacion).FirstOrDefault();
            return cliente is not null;
        }
        public void Editar(Cliente entidad, Guid id)
        {
            var response = repositorioCliente.SeleccionarPorId(id);
            if (response is null)
                throw new ValidarExceptions($"El cliente con identificacion {entidad.Identificacion} no exite");

            response.Modificar(entidad.TipoDocumuento, entidad.Nombre, entidad.Telefono);
            repositorioCliente.Editar(response, id);
            repositorioCliente.GuardarTodosLosCambios();
            
        }

        public void Eliminar(Guid entidad)
        {
            var response = repositorioCliente.SeleccionarPorId(entidad);
            if (response is not null)
                repositorioCliente.Eliminar(entidad);
            else
                throw new ValidarExceptions($"el cliente que desea eliminar no existe");

            repositorioCliente.GuardarTodosLosCambios();
        }

        public List<Cliente> Listar()
        {
            return repositorioCliente.Listar();
        }

        public Cliente SeleccionarPorId(Guid entidad)
        {
            var res = repositorioCliente.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"El cliente que busca no existe");

            return res;
        }
        public Cliente BuscarIdentificacion(string identificacion)
        {
            var response = repositorioCliente.Consultar(x => x.Identificacion == identificacion).FirstOrDefault();
            if (response is null)
                throw new ValidatorDTO("No existe");

            return response;
        }
    }
}
