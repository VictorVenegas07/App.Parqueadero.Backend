using AppParqueadero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IModificar<TEntidad,TEntidadId>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>  
    {
    }
}
