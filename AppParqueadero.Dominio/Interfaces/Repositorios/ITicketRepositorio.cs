using AppParqueadero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface ITicketRepositorio<TEntidad, TEntidadId> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadId>, ITransaccion, IConsulta<TEntidad, bool>
    {
        TEntidad ActualizarEstado(TEntidad entidad, TEntidadId id);
        void Eliminar(TEntidad entidad);

        List<TEntidad> BuscarVariosAsync(Func<TEntidad, bool> expression = null);
    }
}
