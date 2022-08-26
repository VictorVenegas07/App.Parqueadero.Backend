using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Interfaces
{
    public interface IListar <T,Id>
    {
        List<T> Listar();
        T SeleccionarPorId(Id entidad);
    }
}
