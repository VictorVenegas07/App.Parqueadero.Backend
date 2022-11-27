using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioReserva<TEntidad, TEntidadId> :
        IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>, ITransaccion, IModificar<TEntidad,TEntidadId>, IConsulta<TEntidad, bool>
    {
        TEntidad AnularReserva(TEntidad entidad);
        Task<Ticket> GenerarTicket(Ticket entidad);

        Task<bool> ValidaReserva(TEntidadId ReservaId);
    }
}
