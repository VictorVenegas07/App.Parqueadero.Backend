using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Excepciones
{
    public class ValidarExceptions: Exception
    {
        public ValidarExceptions(string mensaje):base(mensaje)
        {

        }
    }
}
