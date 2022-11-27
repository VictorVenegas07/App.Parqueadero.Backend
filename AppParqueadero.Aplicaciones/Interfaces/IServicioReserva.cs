using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface IServicioReserva<TEntidad, TEntidadId>: IAgregar<TEntidad>, IListar<TEntidad,TEntidadId>, IModificar<TEntidad,TEntidadId>
    {
        TEntidad AnularReserva(TEntidadId entidad);

        Task<Ticket> GenerarTicket(Ticket entidad, TEntidadId reservaId);

        Task<bool> ValidaReserva(TEntidadId ReservaId);

        IEnumerable<TEntidad> BuscarReservaCliente(string identificacion);


    }
}
