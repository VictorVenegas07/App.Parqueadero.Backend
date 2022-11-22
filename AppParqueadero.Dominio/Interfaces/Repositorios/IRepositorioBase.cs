using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppParqueadero.Dominio.Interfaces;

namespace AppParqueadero.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadId>
        : IAgregar<TEntidad>, IModificar<TEntidad, TEntidadId>, IEliminar<TEntidadId>, IListar<TEntidad, TEntidadId>,ITransaccion, IConsulta<TEntidad, bool>
    {
    }
}
