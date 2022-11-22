using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces;
using AppParqueadero.Dominio.Interfaces.Repositorios;

namespace AppParquadero.Infraestructura.Datos.Repositorios
{
    public class VehiculoRepositorio : IRepositorioBase<Vehiculo, Guid>
    {
        ParqueaderoContexto contexto;
        public VehiculoRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Vehiculo Agregar(Vehiculo entidad)
        {
            
            contexto.Vehiculos.Add(entidad);
            return entidad;
        }

        public void Editar(Vehiculo entidad, Guid id)
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

        public List<Vehiculo> Listar()
        {
           return contexto.Vehiculos.ToList();
        }

        public Vehiculo SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Vehiculos.Where(v => v.VehiculoId == entidad).FirstOrDefault();
            return respuesta;
        }


        public List<Vehiculo> Consultar(Func<Vehiculo, bool> expression = null)
        {
            if(expression != null)
                return contexto.Vehiculos.Where(expression).ToList();

            return contexto.Vehiculos.ToList();
        }
    }
}
