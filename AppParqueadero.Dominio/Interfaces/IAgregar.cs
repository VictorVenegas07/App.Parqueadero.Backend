using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Interfaces
{
    public interface IAgregar<T>
    {
        T Agregar(T entidad);
    }
}
