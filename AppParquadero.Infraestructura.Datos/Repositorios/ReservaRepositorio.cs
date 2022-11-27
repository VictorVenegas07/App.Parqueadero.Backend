using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio;
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
    public class ReservaRepositorio : IRepositorioReserva<Reserva, Guid>
    {
        ParqueaderoContexto contexto;
        public ReservaRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Reserva Agregar(Reserva entidad)
        {
            contexto.reservas.Add(entidad);
            return entidad;
        }

        public Reserva AnularReserva(Reserva entidad)
        {
            contexto.reservas.Update(entidad);
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entidad;
        }

        public List<Reserva> Consultar(Func<Reserva, bool> expression = null)
        {
            if (expression != null)
                return contexto.reservas
                    .Include(x => x.Puesto)
                    .Include(x => x.cliente)
                    .Include(x => x.Vehiculo)
                    .Where(expression).ToList();
            return contexto.reservas.ToList();
        }

        public void Editar(Reserva entidad, Guid id)
        {
            contexto.reservas.Update(entidad);
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task<Ticket> GenerarTicket(Ticket entidad)
        {
            await contexto.Tickets.AddAsync(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de guardar los datos: "+ex.Message);
            }
        }

        public List<Reserva> Listar()
        {
            return contexto.reservas
                .Include(x=> x.Puesto)
                .Include(x=> x.cliente)
                .Include(x => x.Vehiculo)
                .ToList();
        }

        public Reserva SeleccionarPorId(Guid entidad)
        {
            return contexto.reservas
                 .Include(x => x.Vehiculo)
                .Include(x => x.cliente)
                .Include(x => x.Puesto)
                .Where(c => c.ReservaId == entidad)
                 .OrderBy(c => c.ReservaId)
                 .FirstOrDefault();
        }

        public async Task<bool> ValidaReserva(Guid reservaId)
        {
            return await contexto.reservas.AnyAsync(x => x.ReservaId == reservaId);
        }
    }
}
