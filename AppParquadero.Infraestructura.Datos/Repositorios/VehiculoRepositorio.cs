using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Interfaces.Repositorios;

namespace AppParquadero.Infraestructura.Datos.Repositorios
{
    internal class VehiculoRepositorio : IRepositorioBase<Vehiculo, Guid>
    {
        ParqueaderoContexto contexto;
        public VehiculoRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Vehiculo Agregar(Vehiculo entidad)
        {
            entidad.VehiculoId = Guid.NewGuid();
            contexto.Vehiculos.Add(entidad);
            return entidad;
        }

        public void Editar(Vehiculo entidad)
        {
            var respuesta = contexto.Vehiculos.Where(v => v.VehiculoId == entidad.VehiculoId).FirstOrDefault();
            if (respuesta != null)
            {
                respuesta.Marca = entidad.Marca;
                respuesta.Placa = entidad.Placa;
                respuesta.Modelo = entidad.Modelo;
                respuesta.Tipo = entidad.Tipo;
                contexto.Entry(respuesta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }

        public void Eliminar(Guid entidad)
        {
            var respuesta = contexto.Vehiculos.Where(v => v.VehiculoId == entidad).FirstOrDefault();
            if (respuesta != null)
            {
                contexto.Vehiculos.Remove(respuesta);
            }
        }

        public void GuardarTodosLosCambios()
        {
            contexto.SaveChanges();
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
    }
}
