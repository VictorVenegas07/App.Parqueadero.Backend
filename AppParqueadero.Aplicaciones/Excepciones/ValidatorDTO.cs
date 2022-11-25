using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Excepciones
{
    public class ValidatorDTO:Exception
    {
        public ValidatorDTO(string mensaje):base(mensaje)
        {

        }
    }
}
