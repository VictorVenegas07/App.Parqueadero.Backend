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
    public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {
        ParqueaderoContexto contexto;
        public ClienteRepositorio(ParqueaderoContexto _contexto)
        {
            contexto = _contexto;
        }
        public Cliente Agregar(Cliente entidad)
        {
            contexto.Clientes.Add(entidad);
            return entidad;
        }

        public void Editar(Cliente entidad, Guid id)
        {
            contexto.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Eliminar(Guid entidad)
        {
            var res = contexto.Clientes.Find(entidad);
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
        public Cliente BuscarCliente(string identificacion)
        {
            var respuesta = contexto.Clientes.FirstOrDefault(x => x.Identificacion == identificacion);
            return (respuesta != null) ? respuesta : null;
        }

        

        public List<Cliente> Consultar(Func<Cliente, bool> expression = null)
        {
            if (expression != null)
                return contexto.Clientes.Where(expression).ToList();
            return contexto.Clientes.ToList();
        }
    }
}
