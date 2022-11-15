using AppParquadero.Infraestructura.Datos.Contexto;
using System;

namespace AppParquadero.Infraestructura.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aca se crea la base de datos
            ParqueaderoContexto db = new ParqueaderoContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("se creo con exito");
            Console.ReadKey();

        }
    }
}
