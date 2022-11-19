using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class EmpledoRepositorio : IRepositorioBase<Empleado, Guid>
    {
        ParqueaderoContexto contexto;
        public EmpledoRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Empleado Agregar(Empleado entidad)
        {
            contexto.Empleados.Add(entidad);
            return entidad;
        }

        public List<Empleado> Consultar(Func<Empleado, bool> expression = null)
        {
            if (expression != null)
                return contexto.Empleados.Where(expression).ToList();
            return contexto.Empleados.ToList();
        }

        public void Editar(Empleado entidad)
        {
            var respuesta = contexto.Empleados.Where(c => c.EmpleadoId == entidad.EmpleadoId)
                .OrderBy(c => c.EmpleadoId)
                .FirstOrDefault();
            if (respuesta != null)
            {
                respuesta.Nombre = entidad.Nombre;
                respuesta.Email = entidad.Email;
                contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidad)
        {
            var respuesta = contexto.Empleados.Where(c => c.EmpleadoId == entidad)
              .OrderBy(c => c.EmpleadoId)
              .FirstOrDefault();
            if (respuesta != null)
            {
                contexto.Empleados.Remove(respuesta);
            }
        }

        public void GuardarTodosLosCambios()
        {
            try
            {
                contexto.SaveChanges();

            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar");
            }
        }

        public List<Empleado> Listar()
        {
            return contexto.Empleados.ToList();
        }

        public Empleado SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Empleados.Find(entidad);
            return respuesta;
        }
    }
}
