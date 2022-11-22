using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class TarifaRepositori : IRepositorioBase<Tarifa, Guid>
    {
        ParqueaderoContexto contexto;
        public TarifaRepositori(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Tarifa Agregar(Tarifa entidad)
        {
            contexto.Tarifas.Add(entidad);
            return entidad;
        }

        public List<Tarifa> Consultar(Func<Tarifa, bool> expression = null)
        {
            if (expression != null)
                return contexto.Tarifas.Where(expression).ToList();
            return contexto.Tarifas.ToList();
        }

        public void Editar(Tarifa entidad, Guid id)
        {
                contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Eliminar(Guid entidad)
        {
            var res = contexto.Tarifas.Find(entidad);
            contexto.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

        }

        public void GuardarTodosLosCambios()
        {
            try
            {
                contexto.SaveChanges();

            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar");
            }
        }

        public List<Tarifa> Listar()
        {
            return contexto.Tarifas.ToList();
        }

        public Tarifa SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Tarifas.Find(entidad);
            return respuesta;
        }
    }
}
