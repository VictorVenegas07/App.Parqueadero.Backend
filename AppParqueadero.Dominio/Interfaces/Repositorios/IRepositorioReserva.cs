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
        void AnularReserva(TEntidad entidad);
    }
}
