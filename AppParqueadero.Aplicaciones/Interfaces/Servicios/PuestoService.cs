using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class PuestoService : IServicioBase<Puesto, Guid>
    {
        private readonly IRepositorioBase<Puesto, Guid> repositorioPuesto;
        public PuestoService(IRepositorioBase<Puesto, Guid> repositorioPuesto_)
        {
            repositorioPuesto = repositorioPuesto_;
        }

        public Puesto Agregar(Puesto entidad)
        {
            Puesto puesto;
            if (ValidarPuesto(entidad))
                puesto = repositorioPuesto.Agregar(entidad);
            else
                throw new ValidarExceptions($"El puesto con codigo {entidad.CodigoPuesto} ya exite");


            repositorioPuesto.GuardarTodosLosCambios();
            return puesto;
        }
        private bool ValidarPuesto(Puesto entidad)
        {
            var puesto = repositorioPuesto.Consultar(x => x.CodigoPuesto == entidad.CodigoPuesto).FirstOrDefault();
            return puesto is null;
        }
        public void Editar(Puesto entidad, Guid id)
        {
            var response = repositorioPuesto.SeleccionarPorId(id);
            if (response is null)
                throw new ValidarExceptions($"El puesto no exite");
            response.Modificar("Ocupado");
            repositorioPuesto.Editar(response, id);
            repositorioPuesto.GuardarTodosLosCambios();

        }

        public void Eliminar(Guid entidad)
        {
            var response = repositorioPuesto.SeleccionarPorId(entidad);
            if (response is not null)
                repositorioPuesto.Eliminar(entidad);
            else
                throw new ValidarExceptions($"El puesto que desea eliminar no existe");

            repositorioPuesto.GuardarTodosLosCambios();
        }

        public List<Puesto> Listar()
        {
            return repositorioPuesto.Listar();
        }

        public Puesto SeleccionarPorId(Guid entidad)
        {

            var res = repositorioPuesto.SeleccionarPorId(entidad);
            if (res is null)
                throw new ValidarExceptions($"El puesto que busca no existe");

            return res;

        }
    }
}
