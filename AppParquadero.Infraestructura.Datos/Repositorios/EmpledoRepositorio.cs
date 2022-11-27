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

        public void Editar(Empleado entidad, Guid id)
        {
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Eliminar(Guid entidad)
        {
            var res = contexto.Empleados.Find(entidad);
            contexto.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

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
            var respuesta = contexto.Empleados
                .Include(x=> x.Usuario)
                .Where(x=> x.EmpleadoId==entidad)
                .FirstOrDefault();
            return respuesta;
        }
    }
}
