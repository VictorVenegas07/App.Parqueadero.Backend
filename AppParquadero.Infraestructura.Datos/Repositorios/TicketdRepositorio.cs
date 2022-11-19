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
    public class TicketdRepositorio : IRepositorioBase<Ticket, Guid>
    {
        ParqueaderoContexto contexto;
        public TicketdRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Ticket Agregar(Ticket entidad)
        {
            contexto.Tickets.Add(entidad);
            return entidad;
        }

        public List<Ticket> Consultar(Func<Ticket, bool> expression = null)
        {
            if (expression != null)
                return contexto.Tickets.Where(expression).ToList();
            return contexto.Tickets.ToList();
        }

        public void Editar(Ticket entidad)
        {
            var respuesta = contexto.Tickets.Where(c => c.TickedId == entidad.TickedId)
                .OrderBy(c => c.EmpleadoId)
                .FirstOrDefault();
            if (respuesta != null)
            {
                contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidad)
        {
            var respuesta = contexto.Tickets.Where(c => c.TickedId == entidad)
              .OrderBy(c => c.EmpleadoId)
              .FirstOrDefault();
            if (respuesta != null)
            {
                contexto.Tickets.Remove(respuesta);
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

                throw new Exception("Error al tratar de guardar "+e.InnerException.Message);
            }
        }

        public List<Ticket> Listar()
        {
            return contexto.Tickets.ToList();
        }

        public Ticket SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Tickets.Find(entidad);
            return respuesta;
        }
    }
}
