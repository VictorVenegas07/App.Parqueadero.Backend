using AppParqueadero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface IServicioReserva<TEntidad, TEntidadId>: IAgregar<TEntidad>, IListar<TEntidad,TEntidadId>, IModificar<TEntidad>
    {
        void AnularReserva(TEntidad entidad);
    }
}
