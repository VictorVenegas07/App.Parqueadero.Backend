using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class PuestoRepositorio : IRepositorioBase<Puesto, Guid>
    {
        private readonly ParqueaderoContexto contexto;
        public PuestoRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Puesto Agregar(Puesto entidad)
        {
            contexto.Puestos.Add(entidad);
            return entidad;
        }

        public void Editar(Puesto entidad)
        {
            contexto.Puestos.Update(entidad);
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Eliminar(Guid entidad)
        {
            var puesto = SeleccionarPorId(entidad);
            if (puesto != null)
                contexto.Puestos.Remove(puesto);
        }

        public void GuardarTodosLosCambios()
        {
            contexto.SaveChanges();
        }

        public List<Puesto> Listar()
        {
            return contexto.Puestos.ToList();
        }

        public Puesto SeleccionarPorId(Guid entidad)
        {
            return contexto.Puestos.Find(entidad);
        }


        public List<Puesto> Consultar(Func<Puesto, bool> expression = null)
        {
            if (expression != null)
                return contexto.Puestos.Where(expression).ToList();
            return contexto.Puestos.ToList();
        }
    }
}
