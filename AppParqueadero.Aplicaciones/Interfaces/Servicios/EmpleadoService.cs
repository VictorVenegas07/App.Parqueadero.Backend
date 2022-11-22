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
    public class EmpleadoService : IServicioBase<Empleado, Guid>
    {
        private readonly IRepositorioBase<Empleado,Guid> repositorioEmpleado;
        public EmpleadoService(IRepositorioBase<Empleado,Guid> repositorioEmpleado_)
        {
            repositorioEmpleado = repositorioEmpleado_;
        }
        public Empleado Agregar(Empleado entidad)
        {
            Empleado empleado;
            if (ValidarEmpleado(entidad))
                empleado = repositorioEmpleado.Agregar(entidad);
            else
                throw new ValidarExceptions($"El empleado con identificacion {entidad.Identificacion} ya exite");


            repositorioEmpleado.GuardarTodosLosCambios();
            return empleado;
        }

        private bool ValidarEmpleado(Empleado entidad)
        {
            var empleado = repositorioEmpleado.Consultar(x => x.Identificacion == entidad.Identificacion).FirstOrDefault();
            return empleado is null;
        }

        public void Editar(Empleado entidad,Guid id)
        {
            var response = repositorioEmpleado.SeleccionarPorId(id);
            if (response is null)
                throw new ValidarExceptions($"El empleado con identificacion {entidad.Identificacion} no exite");

            response.Modificar(entidad.TipoDocumuento, entidad.Nombre,entidad.Telefono, entidad.Email);
            repositorioEmpleado.Editar(response, id);
            repositorioEmpleado.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidad)
        {
            var response = repositorioEmpleado.SeleccionarPorId(entidad);
            if (response is not null)
                repositorioEmpleado.Eliminar(entidad);
            else
                throw new ValidarExceptions($"El empleado que desea eliminar no existe");

            repositorioEmpleado.GuardarTodosLosCambios();

        }

        public List<Empleado> Listar()
        {
            return repositorioEmpleado.Listar();
        }

        public Empleado SeleccionarPorId(Guid entidad)
        {
            var res = repositorioEmpleado.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"El empleado que busca no existe");

            return res;
        }
    }
}
