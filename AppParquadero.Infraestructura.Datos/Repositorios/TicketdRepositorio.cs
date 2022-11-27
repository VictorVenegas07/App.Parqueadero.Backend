using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces;
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
    public class TicketdRepositorio : ITicketRepositorio<Ticket, Guid>
    {
        ParqueaderoContexto contexto;
        public TicketdRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }

        public Ticket ActualizarEstado(Ticket entidad, Guid id)
        {
                contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entidad;
        }

        public Ticket Agregar(Ticket entidad)
        {
            contexto.Tickets.Add(entidad);
            return entidad;
        }

        public List<Ticket> BuscarVariosAsync(Func<Ticket, bool> expression = null)
        {

            return  contexto.Tickets
                  .Include(x => x.Tarifa)
                    .Include(x => x.Vehiculo)
                    .Include(x => x.Cliente)
                    .Include(x => x.Empleado)
                    .Include(x => x.Puesto)
                .Where(expression).OrderBy(x=> x.Cliente.Identificacion).ToList();
        }

        public List<Ticket> Consultar(Func<Ticket, bool> expression = null)
        {
            if (expression != null)
                return contexto.Tickets
                    .Include(x => x.Tarifa)
                    .Include(x=> x.Vehiculo)
                    .Include(x=> x.Cliente)
                    .Include(x => x.Empleado)
                    .Include(x=> x.Puesto)
                    .Where(expression).ToList();
            return contexto.Tickets.ToList();
        }

 

        public void Eliminar(Ticket entidad)
        {
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
            return contexto.Tickets
                .Include(x => x.Tarifa)
                .Include(x => x.Vehiculo)
                .Include(x => x.Cliente)
                .Include(x=> x.Puesto)
                .Include(x=> x.Empleado)
                .OrderBy(x=> x.Estado == "Entrada")
                .ToList();
        }

        public Ticket SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Tickets.Where(x=> x.TickedId == entidad)
                .Include(x => x.Tarifa)
                .Include(x => x.Vehiculo)
                .Include(x => x.Cliente)
                .Include(x=> x.Empleado)
                .Include(x => x.Puesto).FirstOrDefault();
            return respuesta;
        }
    }
}
