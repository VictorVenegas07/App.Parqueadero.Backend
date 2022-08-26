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
    internal class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {
        ParqueaderoContexto contexto;
        public ClienteRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Cliente Agregar(Cliente entidad)
        {
            Guid id = Guid.NewGuid();
            contexto.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad)
        {
           var respuesta = contexto.Clientes.Where(c => c.ClienteId == entidad.ClienteId)
                .OrderBy(c=> c.ClienteId)
                .FirstOrDefault();
            if (respuesta!= null)
            {
                respuesta.TipoDocumuento = entidad.TipoDocumuento;
                respuesta.Telefono = entidad.Telefono;
                respuesta.Nombre = entidad.Nombre;
                respuesta.Telefono = entidad.Telefono;
                contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidad)
        {
            var respuesta = contexto.Clientes.Where(c => c.ClienteId == entidad)
                .OrderBy(c => c.ClienteId)
                .FirstOrDefault();
            if (respuesta != null)
            {
                contexto.Clientes.Remove(respuesta);
            }
        }

        public void GuardarTodosLosCambios()
        {
            contexto.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return contexto.Clientes.ToList();
        }

        public Cliente SeleccionarPorId(Guid entidad)
        {
            var respuesta = contexto.Clientes.Where(c => c.ClienteId == entidad)
                .OrderBy(c => c.ClienteId)
                .FirstOrDefault();
            return respuesta;
    }
}
