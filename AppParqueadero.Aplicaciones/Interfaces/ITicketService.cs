using AppParqueadero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface ITicketService<TEntidad, TEntidadId> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>
    {
        TEntidad ActualizarEstado(TEntidadId id);
        void Eliminar(TEntidadId id);

        List<TEntidad> BuscarVariosAsync(string identificacion, string placa, string estado, DateTime fecha);
    }
}
